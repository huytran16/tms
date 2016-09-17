﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AMS.Constant;
using AMS.Repository;

namespace AMS.Service
{
    public class UserServices
    {
        GenericRepository<User> userRepository = new GenericRepository<User>();

        public User FindById(int id)
        {
            return userRepository.FindById(id);
        }

        public bool FindByUserName(string username)
        {
            return userRepository.List.Any(u => u.Username.Equals(username));
        }
       
        public List<User> GetAllUnapproveUsers()
        {
            return
                userRepository.List.Where(
                    u => u.RoleId == SLIM_CONFIG.USER_ROLE_RESIDENT
                    && u.Status != null && u.Status == SLIM_CONFIG.USER_APPROVE_WAITING).ToList();
        }
        public List<User> GetAllUsers()
        {
            return userRepository.List.ToList();
               
        }

        public void Update(User u)
        {
            userRepository.Update(u);
        }

        public void Add(User u)
        {
            userRepository.Add(u);
        }

        public List<User> GetAllResident()
        {
            return userRepository.List.Where(u => u.Status != null && u.Status == SLIM_CONFIG.USER_STATUS_ENABLE
                && (u.RoleId == SLIM_CONFIG.USER_ROLE_RESIDENT || u.RoleId == SLIM_CONFIG.USER_ROLE_HOUSEHOLDER)).
                OrderByDescending(userRepository => userRepository.CreateDate)
                    .ToList();
        }
        public List<User> GetAllSupporter()
        {
            return userRepository.List.Where(u => u.Status != null && u.Status == SLIM_CONFIG.USER_STATUS_ENABLE && u.RoleId == SLIM_CONFIG.USER_ROLE_SUPPORTER).
                OrderByDescending(userRepository => userRepository.CreateDate)
                    .ToList();
        }
        public List<User> GetAllManager()
        {
            return userRepository.List.Where(u => u.Status != null && u.Status == SLIM_CONFIG.USER_STATUS_ENABLE && u.RoleId == SLIM_CONFIG.USER_ROLE_MANAGER).
                OrderByDescending(userRepository => userRepository.CreateDate)
                    .ToList();
        }
    }
}