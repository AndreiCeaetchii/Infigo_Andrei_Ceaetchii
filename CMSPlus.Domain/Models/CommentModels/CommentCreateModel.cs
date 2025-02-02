namespace CMSPlus.Domain.Models.CommentModels;

public class CommentCreateModel:BaseCommentModel
{
    public String FullName { get; set; }
    public String Body { get; set; }
    public int TopicId { get; set; }
}