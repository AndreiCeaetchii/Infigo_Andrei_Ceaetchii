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

    public CommentController(ICommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
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

        return RedirectToAction("Index", "Home");
    }
    
}