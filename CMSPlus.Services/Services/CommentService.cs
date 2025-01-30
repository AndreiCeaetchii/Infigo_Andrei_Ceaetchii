using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Services.Interfaces;

namespace CMSPlus.Services.Services;

public class CommentService: ICommentService
{
    private readonly ICommentRepository _repository;

    public CommentService(ICommentRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<CommentEntity> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<IEnumerable<CommentEntity>> GetCommentsByTopicId(int topicid)
    {
        return await _repository.GetCommentsByTopicId(topicid);
    }

    public async Task<IEnumerable<CommentEntity>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task Create(CommentEntity entity)
    {
        await _repository.Create(entity);
    }

    public async Task Update(CommentEntity entity)
    {
        await _repository.Update(entity);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
}