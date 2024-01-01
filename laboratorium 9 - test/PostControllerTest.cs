using Data;
using Laboratorium_3.Controllers;
using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace laboratorium_9___test;

public class PostControllerTest
{
    private PostController _controller;
    private IPostService _postService;
    private CurrentDateTimeProvider _dateTimeProvider;


    public PostControllerTest()
    {
        _dateTimeProvider = new CurrentDateTimeProvider();
        _postService = new MemoryPostService(_dateTimeProvider);

        _postService.Add(new Post() { Author = "Test1", Content = "Test1", PublicationDate = _dateTimeProvider.dateNow(), TagId = 1 });
        _postService.Add(new Post() { Author = "Test2", Content = "Test2", PublicationDate = _dateTimeProvider.dateNow(), TagId = 2 });
        _postService.Add(new Post() { Author = "Test3", Content = "Test3", PublicationDate = _dateTimeProvider.dateNow(), TagId = 3 });
        _postService.Add(new Post() { Author = "Test4", Content = "Test4", PublicationDate = _dateTimeProvider.dateNow(), TagId = 4 });
        _postService.Add(new Post() { Author = "Test5", Content = "Test5", PublicationDate = _dateTimeProvider.dateNow(), TagId = 5 });

        _postService.AddComment(new Comment() { PostId = 1, Author = "Comment1", Content = "Comment1", PublicationDate = _dateTimeProvider.dateNow() });
        _postService.AddComment(new Comment() { PostId = 2, Author = "Comment1", Content = "Comment1", PublicationDate = _dateTimeProvider.dateNow() });
        _postService.AddComment(new Comment() { PostId = 3, Author = "Comment1", Content = "Comment1", PublicationDate = _dateTimeProvider.dateNow() });
        _postService.AddComment(new Comment() { PostId = 4, Author = "Comment1", Content = "Comment1", PublicationDate = _dateTimeProvider.dateNow() });
        _postService.AddComment(new Comment() { PostId = 5, Author = "Comment1", Content = "Comment1", PublicationDate = _dateTimeProvider.dateNow() });

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
    [InlineData(1,2)]
    [InlineData(2,2)]
    [InlineData(3,2)]
    public void PagedIndexWithoutTag(int page, int size)
    {
        var result = _controller.PagedIndex(0, page, size);
        Assert.IsType<ViewResult>(result);
        
        var view = result as ViewResult;
        Assert.IsType<PagingList<Post>>(view.Model);
        PagingList<Post>? pagingList = view.Model as PagingList<Post>;
        Assert.NotNull(pagingList);
        Assert.Equal(_postService.FindPage(page, size, _postService.FindAll()).Data.Count(), pagingList.Data.Count());
    }
    
    [Theory]
    [InlineData(1,1,1)]
    [InlineData(2,2,3)]
    [InlineData(3,1,1)]
    [InlineData(4,1,4)]
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
        Post model = new Post() { Author = "Test", Content = "Test", PublicationDate = _dateTimeProvider.dateNow(), TagId = 1};
        var prevCount = _postService.FindAll().Count;
        var result = _controller.Create(model);
        Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal(prevCount +1, _postService.FindAll().Count());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void UpdateForExisingPost(int id)
    {
        var post = _postService.FindById(id);
        Assert.NotNull(post);
        post.Content = "Update";
        post.Author = "Update";
        _controller.Update(post);
        var updatedPost = _postService.FindById(id);
        Assert.NotNull(updatedPost);
        Assert.Equal("Update", updatedPost.Author);
        Assert.Equal("Update", updatedPost.Content);
    }

    [Fact]
    public void UpdateForNonExisingPost()
    {
        Post newPost = new Post() { Id = 6, Author = "Test" };
        var result = _controller.Update(newPost);
        Assert.IsType<RedirectToActionResult>(result);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void DetailsForExisingPost(int id)
    {
        var result = _controller.Details(id);
        Assert.IsType<ViewResult>(result);
        var view = result as ViewResult;
        Assert.NotNull(view);
        Assert.IsType<Post>(view.Model);
        Post? model = view.Model as Post;
        Assert.NotNull(model);
        Assert.Equal(id, model.Id);
    }
    
    [Fact]
    public void DetailsForNonExisingPost()
    {
        var result = _controller.Details(6);
        Assert.IsType<NotFoundResult>(result);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void DeleteForExisingPost(int id)
    {
        var oldCount = _postService.FindAll().Count;
        Post? post = _postService.FindById(id);
        Assert.NotNull(post);
        _controller.Delete(post);
        Assert.Equal(oldCount - 1, _postService.FindAll().Count());
    }
    
    [Fact]
    public void DeleteForNonExisingPost()
    {
        int oldCount = _postService.FindAll().Count;
        Post post = new Post() { Id = 1000, Author = "Post", Content = "Post" };
        _controller.Delete(post);
        Assert.Equal(oldCount, _postService.FindAll().Count());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void AddComment(int postId)
    {
        string author = "Comment";
        string content = "Comment";
        var result = _controller.AddComment(postId, author, content);
        Assert.IsType<RedirectToActionResult>(result);
    }
}