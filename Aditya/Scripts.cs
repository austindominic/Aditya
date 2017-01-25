using Aditya.Models.Blog;
using Aditya.Models.Gallery;
using Aditya.Models.Menu;
using Aditya.Models.Page;
using Aditya.Models.Repository.Blog;
using Aditya.Models.Repository.Menu;
using Aditya.Models.Repository.Page;
using Aditya.Models.Repository.Program;
using Aditya.Models.Repository.User;
using Aditya.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aditya
{
    public class Scripts
    {
        private BlogCategoryRepository _blogCategoryRepository = new BlogCategoryRepository();
        private BlogContentRepository _blogContentRepository = new BlogContentRepository();
        private BlogTagsRepository _blogTagsRepository = new BlogTagsRepository();
        private UserCommentsRepository _BlogCommentRepository = new UserCommentsRepository();
        private MainMenuRepository _mainMenuRepository = new MainMenuRepository();
        private DailyMessagesRepository _dailyMessagesRepository = new DailyMessagesRepository();
       
        private ApplicationRepository _applicationRepository = new ApplicationRepository();
       
        private PageContentRepository _pageContentRepository = new PageContentRepository();

        public List<BlogCategory> blogCategorySiedbar()
        {
            return _blogCategoryRepository.GetAll();
        }

        public List<BlogContent> blogContentMain()
        {

            return _blogContentRepository.GetAll().OrderByDescending(m => m.BlogPostingDate).ToList();
        }

        public List<BlogContent> blogContentSiedbar()
        {
            var blogData = _blogContentRepository.GetAll().OrderByDescending(m => m.BlogPostingDate);
            return blogData.Take(5).ToList();
        }

        public List<BlogTagsMain> listBlogTags()
        {
            return _blogTagsRepository.GetAll();
        }

        public List<UserComments> listBlogComments()
        {
            var result = _BlogCommentRepository.GetAll().Where(t => t.isApproved = true).OrderByDescending(t => t.CreatedDate);
            return result.Take(5).ToList();
        }

        public List<MainMenu> menuMainHeader(string rootName)
        {
            return _mainMenuRepository.mainMenu(rootName);
        }

        public List<PageContent> galleryPageContent()
        {
            return _pageContentRepository.GetAll();
        }

        public List<GalleryMain> getGalleryByMonth(int id)
        {
            var results = _pageContentRepository.Get(id).GalleryMain;
            return results.ToList();
        }

        public string currentMonth(int iMonthNo)
        {
            DateTime dtDate = new DateTime(DateTime.Now.Year, iMonthNo, 1);
            return dtDate.ToString("MMM");
        }

        public List<DailyMessage> OneLineDailyMessage()
        {
            return _dailyMessagesRepository.TodaysMessage();
        }



        public bool Admin()
        {
            if (HttpContext.Current.Session["isAdmin"] != null)
                return true;
            else
                return true;
        }

        public bool isUserActive()
        {

            if (HttpContext.Current.Session["userUid"] != null)
                return true;
            else
                return false;
        }


        //Get all the Blog Comments

        public List<UserComments> GetBlogComment(int blogContentId)
        {
            return _BlogCommentRepository.GetBlogComment(blogContentId);
        }

      
    }

}