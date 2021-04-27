using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class CommentBusinessService : ICommentBusinessService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CommentBusinessService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int commentId)
        {
            Comment comment = GetById(commentId);
            _commentRepository.Delete(comment);
            _unitOfWork.Complete();
        }

        public List<Comment> GetAll()
        {
            return _commentRepository.All();
        }

        public Comment GetById(int commentId)
        {
            return _commentRepository.FindById(commentId);
        }

        public void Save(Comment comment)
        {
            _commentRepository.Add(comment);
            _unitOfWork.Complete();
        }

        public void Update(Comment comment)
        {
            _commentRepository.Update(comment);
            _unitOfWork.Complete();
        }
    }
}
