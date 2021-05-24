using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using CloudinaryDotNet;
using API.Repos;
using API.Services;
using AutoMapper;
using Microsoft.Extensions.Options;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.ServicesImpl
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IMapper mapper;
        private readonly IAttachmentRepo attachmentRepo;
        private readonly IOptions<CloudinarySettings> cloudinaryConfig;
        private readonly Cloudinary cloudinary;
        private readonly IFileService fileService;
        public AttachmentService(IMapper mapper, IAttachmentRepo attachmentRepo, 
            IOptions<CloudinarySettings> cloudinaryConfig, IFileService fileService)
        {
            this.fileService = fileService;
            this.cloudinaryConfig = cloudinaryConfig;
            this.attachmentRepo = attachmentRepo;
            this.mapper = mapper;

            Account acc = new Account(
                cloudinaryConfig.Value.CloudName,
                cloudinaryConfig.Value.ApiKey,
                cloudinaryConfig.Value.ApiSecret
            );

            cloudinary = new Cloudinary(acc);
        }
    public async Task<IAsyncResult> AddAsync(AttachmentToAdd attachmentToAdd)
    {
        attachmentToAdd.Url = fileService.AddFile(attachmentToAdd.File, cloudinary);

        var attachment = mapper.Map<Attachment>(attachmentToAdd);

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

    public async Task<IEnumerable<AttachmentToReturn>> GetAllAsync()
    {
        var attachments = await attachmentRepo.GetAllAsync();

        if (attachments == null || attachments.Count() == 0) throw new Exception("No attachments");

        var attachmentsToReturn = mapper.Map<IEnumerable<AttachmentToReturn>>(attachments);

        return attachmentsToReturn;
    }

    public async Task<AttachmentToReturn> GetAsync(int attachmentId)
    {
        var attachment = await attachmentRepo.GetAsync(attachmentId);

        if (attachment == null) throw new Exception("Not found");

        var attachmentToReturn = mapper.Map<AttachmentToReturn>(attachment);

        return attachmentToReturn;
    }
}
}