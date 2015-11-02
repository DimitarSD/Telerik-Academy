namespace StudentSystem.Web.Models
{
    using System;

    using StudentSystem.Models;

    public class HomeworkDataModel
    {
        public static Func<Homework, HomeworkDataModel> FromDataToModel
        {
            get
            {
                return h => new HomeworkDataModel
                {
                    FileUrl = h.FileUrl,
                    TimeSent = h.TimeSent
                };
            }
        }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }
          
        public static Homework FromModelToData(HomeworkDataModel homeworkModel)
        {
            return new Homework
            {
                FileUrl = homeworkModel.FileUrl,
                TimeSent = homeworkModel.TimeSent
            };
        }
    }
}