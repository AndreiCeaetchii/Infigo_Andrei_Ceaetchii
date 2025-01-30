using CMSPlus.Domain.Models.TopicModels;

namespace CMSPlus.Domain.Models.CommentModels;

public class CommentModel:BaseCommentModel
{
    public CommentModel()
    {
        UpdatedOnUtc = CreatedOnUtc = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Body { get; set; }
    public int TopicId { get; set; }
    public DateTime? CreatedOnUtc { get; set; }
    public DateTime? UpdatedOnUtc { get; set; }
    
    public TopicModel Topic { get; set; }
    
}