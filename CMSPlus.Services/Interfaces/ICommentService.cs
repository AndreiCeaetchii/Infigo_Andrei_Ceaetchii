using CMSPlus.Domain.Entities;

namespace CMSPlus.Services.Interfaces;

public interface ICommentService
{
    public Task<CommentEntity> GetById(int id);
    public Task<IEnumerable<CommentEntity>> GetCommentsByTopicId(int topicid);
    public Task<IEnumerable<CommentEntity>> GetAll();
    public Task Create(CommentEntity entity);
    public Task Update(CommentEntity entity);
    public Task Delete(int id);
}