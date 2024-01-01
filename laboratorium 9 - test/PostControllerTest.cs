using Data;
using Laboratorium_3.Controllers;
using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace laboratorium_9___test;

public class PostControllerTest
{
    private PostController _controller;
    private IPostService _postService;
    private CurrentDateTimeProvider _dateTimeProvider;
    private AppDbContext _context;

    public PostControllerTest()
    {
        _dateTimeProvider = new CurrentDateTimeProvider();
        _context = new AppDbContext();
        _postService = new EFPostService(_context);
        _controller = new PostController(_postService, _dateTimeProvider);
    }

    [Fact]
    public void IndexWithoutTag()
    {
        var result = _controller.Index();
        Assert.IsType<ViewResult>(result);
        
        var view = result as ViewResult;
        Assert.IsType<List<Post>>(view.Model);
        List<Post>? list = view.Model as List<Post>;
        Assert.NotNull(list);
        Assert.Equal(_postService.FindAll().Count, list.Count);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void IndexWithTag(int id)
    {
        var result = _controller.Index(id);
        Assert.IsType<ViewResult>(result);
        
        var view = result as ViewResult;
        Assert.IsType<List<Post>>(view.Model);
        List<Post>? list = view.Model as List<Post>;
        Assert.NotNull(list);
        Assert.Equal(_postService.FindByTag(id).Count, list.Count);
    }
    
    [Theory]
    [InlineData(0,1,2)]
    [InlineData(0,2,2)]
    [InlineData(0,3,2)]
    public void PagedIndexWithoutTag(int id, int page, int size)
    {
        var result = _controller.PagedIndex(id, page, size);
        Assert.IsType<ViewResult>(result);
        
        var view = result as ViewResult;
        Assert.IsType<PagingList<Post>>(view.Model);
        PagingList<Post>? pagingList = view.Model as PagingList<Post>;
        Assert.NotNull(pagingList);
        Assert.Equal(_postService.FindPage(page, size, _postService.FindAll()).Data.Count(), pagingList.Data.Count());
    }
    
    [Theory]
    [InlineData(1,1,2)]
    [InlineData(2,2,2)]
    [InlineData(3,1,2)]
    [InlineData(4,1,2)]
    [InlineData(5,1,2)]

    public void PagedIndexWithTag(int id, int page, int size)
    {
        var result = _controller.PagedIndex(id, page, size);
        Assert.IsType<ViewResult>(result);
        
        var view = result as ViewResult;
        Assert.IsType<PagingList<Post>>(view.Model);
        PagingList<Post>? pagingList = view.Model as PagingList<Post>;
        Assert.NotNull(pagingList);
        Assert.Equal(_postService.FindPage(page, size, _postService.FindByTag(id)).Data.Count(), pagingList.Data.Count());
    }

    [Fact]
    public void Create()
    {
        Post model = new Post() { Id = _context.Posts.Count() + 1, Author = "Test", Content = "Test", PublicationDate = _dateTimeProvider.dateNow(), TagId = 1};
        var prevCount = _postService.FindAll().Count;
        var result = _controller.Create(model);
        Assert.Equal(prevCount +1, _postService.FindAll().Count());
        var find = _context.Posts.Find(model.Id);
        Assert.NotNull(find);
        _context.Posts.Remove(find);
        _context.SaveChanges();
    }
    [Fact]
    public void UpdateForExisingPost()
    {
        // bez dodawania nowego entity, zmien istniejace i przywroc do stanu poczatkowego
        Post post = new Post() { Id = _context.Posts.Count() + 1, Author = "Test", Content = "Test", PublicationDate = _dateTimeProvider.dateNow(), TagId = 1};

        _postService.Add(post);
        post.Author = "Update";
        var result = _controller.Update(post);
        Assert.IsType<ViewResult>(result);
        var find = _context.Posts.Find(post.Id);
        Assert.NotNull(find);
        Assert.Equal("Update", find.Author);
        _context.Posts.Remove(find);
        _context.SaveChanges();
    }
    
    [Fact]
    public void UpdateForNonExisingPost()
    {
        
    }
    
    [Fact]
    public void DetailsForExisingPost()
    {
        
    }
    
    [Fact]
    public void DetailsForNonExisingPost()
    {
        
    }
    
    [Fact]
    public void DeleteForExisingPost()
    {
        
    }
    
    [Fact]
    public void DeleteForNonExisingPost()
    {
        
    }
    
    [Fact]
    public void AddCommentForExisingPost()
    {
        
    }
    
    [Fact]
    public void AddCommentForNonExisingPost()
    {
        
    }
    
    [Fact]
    public void DeleteCommentForExisingComment()
    {
        
    }
    
    [Fact]
    public void DeleteCommentForNonExisingComment()
    {
        
    }
}