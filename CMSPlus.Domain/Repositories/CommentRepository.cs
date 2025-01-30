using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CMSPlus.Domain.Repositories;

public class CommentRepository:Repository<CommentEntity>,ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CommentEntity>> GetCommentsByTopicId(int topicId)
    {
        var result = await _dbSet.Where(comment => comment.TopicId == topicId).ToListAsync();
        return result;
    }
}