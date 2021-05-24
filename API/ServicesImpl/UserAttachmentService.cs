using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using API.Models;
using API.Repos;
using API.Services;
using AutoMapper;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.ServicesImpl
{
    public class UserAttachmentService : IUserAttachmentService
    {
        private readonly IMapper mapper;
        private readonly IUserAttachmentRepo attachmentRepo;
        private readonly IFileService fileService;
        private readonly Cloudinary cloudinary;

        public UserAttachmentService(IMapper mapper, IUserAttachmentRepo attachmentRepo, 
            IOptions<CloudinarySettings> cloudinaryConfig, IFileService fileService)
        {
            this.fileService = fileService;
            this.attachmentRepo = attachmentRepo;
            this.mapper = mapper;

            Account acc = new Account(
                cloudinaryConfig.Value.CloudName,
                cloudinaryConfig.Value.ApiKey,
                cloudinaryConfig.Value.ApiSecret
            );

            cloudinary = new Cloudinary(acc);
        }
        public async Task<IAsyncResult> AddAsync(UserAttachmentToAdd attachmentToAdd)
        {
            attachmentToAdd.Url = fileService.AddFile(attachmentToAdd.File, cloudinary);

            var attachment = mapper.Map<UserAttachment>(attachmentToAdd);

            await attachmentRepo.AddAsync(attachment);

            if (await attachmentRepo.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Error adding attachment");
        }

        public async Task<IAsyncResult> DeleteAsync(int attachmentId)
        {
            var attachment = await attachmentRepo.GetAsync(attachmentId);

            if (attachment == null) throw new Exception("Not found");

            attachmentRepo.Delete(attachment);

            if (await attachmentRepo.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Error deleting attachment");
        }

        public async Task<IEnumerable<UserAttachmentToReturn>> GetAllAsync()
        {
            var attachments = await attachmentRepo.GetAllAsync();

            if (attachments == null || attachments.Count() == 0) throw new Exception("No attachments");

            var attachmentsToReturn = mapper.Map<IEnumerable<UserAttachmentToReturn>>(attachments);

            return attachmentsToReturn;
        }

        public async Task<UserAttachmentToReturn> GetAsync(int attachmentId)
        {
            var attachment = await attachmentRepo.GetAsync(attachmentId);

            if (attachment == null) throw new Exception("Not found");

            var attachmentToReturn = mapper.Map<UserAttachmentToReturn>(attachment);

            return attachmentToReturn;
        }
    }
}