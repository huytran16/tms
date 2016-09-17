﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AMS.Repository;
using AMS.ViewModel;
using AMS.ObjectMapping;

namespace AMS.Service
{
    public class PostService
    {
        GenericRepository<Post> postRepository = new GenericRepository<Post>();
        GenericRepository<Comment> commentRepository = new GenericRepository<Comment>();
        public int addPost(Post p)
        {
            postRepository.Add(p);
            return p.Id;
        }

        public void CreatePosts(Post post)
        {
            postRepository.Add(post);
        }
        public Post findPostById(int id)
        {
            var result = postRepository.FindById(id);
            return result;
        }
        public List<Post> getAllPost()
        {
            var result = postRepository.List.Where(t => t.Status != SLIM_CONFIG.POST_STATUS_HIDE).OrderByDescending(t => t.Id).ToList();
            return result;
        }
        public List<PostMapping> getAllPostMapping(int? tokenId, int? houseId)
        {
            List<Post> allPostWithHouseID = new List<Post>();
            List<Post> allRaw = getAllPost();
            List<Post> result = new List<Post>();



            if (houseId != null)
            {
                foreach (Post p in allRaw)
                {
                    if (p.User.HouseId == houseId)
                    {
                        allPostWithHouseID.Add(p);
                    }
                }
            }
            else
            {
                allPostWithHouseID = allRaw;
            }
            allPostWithHouseID.OrderByDescending(p => p.CreateDate);

            int position;
            if (tokenId == null)
            {
                position = -1;
            }
            else
            {
                var lastTokenPost = postRepository.FindById(tokenId);
                position = allPostWithHouseID.FindIndex(p => p.Id == tokenId);

                if (allPostWithHouseID.Count > 0 && (lastTokenPost != null && lastTokenPost.Status != null && lastTokenPost.Status == SLIM_CONFIG.POST_STATUS_HIDE))
                {
                    var listPostNewer = allPostWithHouseID.Where(p => p.CreateDate < lastTokenPost.CreateDate).ToList();
                    if (listPostNewer.Count() != 0)
                    {
                        tokenId = listPostNewer.First().Id;
                        position = allPostWithHouseID.FindIndex(p => p.Id == tokenId) - 1;
                    }
                }

            }
            Post managerFirstPost = allPostWithHouseID.Where(p => p.User.RoleId == SLIM_CONFIG.USER_ROLE_MANAGER).FirstOrDefault();
            for (int i = position + 1; i < allPostWithHouseID.Count && result.Count < SLIM_CONFIG.POST_NUMBER_SOCIAL_FEED; i++)
            {
                if (tokenId != -1 && allPostWithHouseID.ElementAt(i) == managerFirstPost)
                {
                    continue;
                }
                result.Add(allPostWithHouseID.ElementAt(i));
            }
            //Add manager's post to head
            if (tokenId == -1)
            {
                if (managerFirstPost != null)
                {
                    if (result.Contains(managerFirstPost))
                    {

                        result.Remove(managerFirstPost);
                    }
                    result.Insert(0, managerFirstPost);
                }
            }
            //Convert to post Mapping
            List<PostMapping> postMappingResult = new List<PostMapping>();
            foreach (Post p in result)
            {
                PostMapping pMapping = new PostMapping();
                pMapping.Id = p.Id;
                pMapping.Body = p.Body;
                pMapping.CreateDate = p.CreateDate.GetValueOrDefault();
                pMapping.EmbedCode = p.EmbedCode;
                pMapping.UserId = p.UserId;
                pMapping.username = p.User == null ? "Không xác định sở hữu" : p.User.Username;
                pMapping.userProfile = p.User == null || p.User.ProfileImage == null || p.User.ProfileImage.Equals("") ? "/Content/Images/defaultProfile.png" : p.User.ProfileImage;
                pMapping.userFullName = p.User == null ? "Không xác định" : p.User.Fullname;
                pMapping.houseName = p.User.House == null ? "Không xác định" : p.User.House.HouseName;
                pMapping.houseId = p.User.HouseId == null ? 0 : p.User.HouseId.Value;
                postMappingResult.Add(pMapping);
            }
            //Convert to post Mapping

            return postMappingResult;
        }
        public PostMapping getSiglePost(int postId)
        {
            Post p = postRepository.FindById(postId);
            PostMapping pMapping = new PostMapping();
            pMapping.Id = p.Id;
            pMapping.Body = p.Body;
            pMapping.CreateDate = p.CreateDate.GetValueOrDefault();
            pMapping.EmbedCode = p.EmbedCode;
            pMapping.UserId = p.UserId;
            pMapping.username = p.User == null ? "Không xác định sở hữu" : p.User.Username;
            pMapping.userProfile = p.User == null || p.User.ProfileImage == null || p.User.ProfileImage.Equals("") ? "/Content/Images/defaultProfile.png" : p.User.ProfileImage;
            pMapping.userFullName = p.User == null ? "Không xác định" : p.User.Fullname;
            pMapping.houseName = p.User.House == null ? "Không xác định" : p.User.House.HouseName;
            return pMapping;
        }

        public List<Post> getAllPostByRole(int roleId)
        {
            var result = postRepository.List.Where(t => t.User.RoleId == roleId).OrderByDescending(t => t.CreateDate).ToList();
            return result;
        }

        public List<Post> getAllPostById(int id)
        {
            var result = postRepository.List.Where(t => t.Id == id).ToList();
            return result;
        }
        public List<Post> getAllPost(int? tokenId, int? houseId)
        {
            List<Post> result = new List<Post>();
            List<Post> allPost = getAllPost();
            if (houseId != null)
            {
                foreach (Post p in allPost)
                {
                    if (p.User.HouseId == houseId)
                    {
                        result.Add(p);
                    }
                }
            }
            else
            {
                result = allPost;
            }
            return result;
        }

        public IEnumerable<Post> getAllPostNotDe()
        {
            return postRepository.List.ToList();
        }

        public IEnumerable<Post> getCommentBelongPost(int id)
        {
            //   return postRepository.List.ToList().Where(t => t.PostId == id);
            return null;
        }
        public IEnumerable<Post> getCommentPostIdNotNull()
        {
            //   return postRepository.List.ToList().Where(t => t.PostId.HasValue);
            return null;
        }
        public Post getRowPostByPostId(int id)
        {
            //  return postRepository.List.ToList().FirstOrDefault(t => t.PostId.HasValue);
            return null;
        }
        public int GetPostIdByPost(int id)
        {
            return -1;
        }

        public List<Comment> GetCommentByPostId(int postid)
        {
            return commentRepository.List.Where(c => c.postId == postid).ToList();
        }
        public List<Comment> GetCommentByPostIdHasSmallerId(int postid, int lastId)
        {
            return commentRepository.List.Where(c => c.postId == postid && c.id < lastId).ToList();
        }
        public List<CommentMapping> GetNewComment(int postId, int lastCommentId)
        {
            List<Comment> allComment = null;
            if (lastCommentId == 0)
            {
                allComment = commentRepository.List.Where(p => postId == p.postId).ToList();
            }
            else
            {
                allComment = commentRepository.List.Where(p => postId == p.postId && p.id > lastCommentId).ToList();
            }

            List<CommentMapping> result = new List<CommentMapping>();
            foreach (Comment c in allComment)
            {
                CommentMapping cMapping = parseCommentToModel(c);
                result.Add(cMapping);
            }
            return result;
        }

        public Comment findCommentById(int commentId)
        {
            return commentRepository.FindById(commentId);
        }
        public void addComment(Comment c)
        {
            commentRepository.Add(c);
        }
        public void UpdatePost(Post obj)
        {
            //Survey survey = new Survey();
            //survey.Title = obj.Title;
            postRepository.Update(obj);
        }

        private CommentMapping parseCommentToModel(Comment c)
        {
            CommentMapping cMapping = new CommentMapping();
            cMapping.id = c.id;
            cMapping.detail = c.detail;
            cMapping.createdDate = c.createdDate.GetValueOrDefault().ToString("s");
            cMapping.username = c.User.Username;
            cMapping.fullName = c.User.Fullname;
            cMapping.userProfile = c.User.ProfileImage;
            cMapping.userId = c.userId.GetValueOrDefault();
            return cMapping;
        }
    }

}