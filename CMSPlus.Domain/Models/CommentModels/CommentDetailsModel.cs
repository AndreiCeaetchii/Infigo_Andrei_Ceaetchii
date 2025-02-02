using CMSPlus.Domain.Models.TopicModels;

namespace CMSPlus.Domain.Models.CommentModels;

public class CommentDetailsModel:BaseCommentModel
{
    public CommentDetailsModel()
    {
        UpdateOnUtc = CreatedOnUtc = DateTime.UtcNow;
    }
    
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Body { get; set; }
    public DateTime UpdateOnUtc { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    
    public TopicModel Topic { get; set; }
}