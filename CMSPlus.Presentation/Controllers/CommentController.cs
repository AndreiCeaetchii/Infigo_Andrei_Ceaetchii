using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.CommentModels;
using CMSPlus.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMSPlus.Presentation.Controllers;

public class CommentController:Controller
{
    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;
    private readonly ITopicService _topicService;


    public CommentController(ICommentService commentService, IMapper mapper, ITopicService topicService)
    {
        _commentService = commentService;
        _mapper = mapper;
        _topicService = topicService;
    }
    
    [HttpGet]
    public IActionResult Create(int topicid)
    {
        if (topicid == 0) // Ensure topicid is not missing
        {
            return BadRequest("TopicId is required.");
        }
    
        var model = new CommentCreateModel { TopicId = topicid };
        return View(model);
    }

    
    [HttpPost]
    public async Task<IActionResult> Create(CommentCreateModel comment)
    {
        var topicEntity = _mapper.Map<CommentCreateModel, CommentEntity>(comment);
        await _commentService.Create(topicEntity);
        var topic = await _topicService.GetById(comment.TopicId);
        if (topic == null)
        {
            return NotFound("Topic not found.");
        }

        // Redirect to the details page of the specific topic
        return RedirectToAction("Details", "Topic", new { systemName = topic.SystemName });
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(int topicId)
    {
        var comments =  await _commentService.GetCommentsByTopicId(topicId);
        var commentToDisplay = _mapper.Map<IEnumerable<CommentEntity>, IEnumerable<CommentModel>>(comments);
        return View(commentToDisplay);
    }
}