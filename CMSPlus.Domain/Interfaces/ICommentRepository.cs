using CMSPlus.Domain.Entities;

namespace CMSPlus.Domain.Interfaces;

public interface ICommentRepository:IRepository<CommentEntity>
{
    public Task<IEnumerable<CommentEntity>> GetCommentsByTopicId(int topicId);
}