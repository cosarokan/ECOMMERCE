using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface ICommentBusinessService
    {
        /// <summary>
        /// Yorum kaydetme işlemini yapar.
        /// </summary>
        /// <param name="comment"></param>
        void Save(Comment comment);

        /// <summary>
        /// Yorum güncelleme işlemini yapar.
        /// </summary>
        /// <param name="comment"></param>
        void Update(Comment comment);

        /// <summary>
        /// Yorum silme işlemini yapar.
        /// </summary>
        /// <param name="commentId"></param>
        void Delete(int commentId);

        /// <summary>
        /// Tüm Yorum kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<Comment> GetAll();

        /// <summary>
        /// Id'ye göre Yorum kaydını döndürür.
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        Comment GetById(int commentId);
    }
}
