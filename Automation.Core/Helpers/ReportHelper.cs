using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Automation.Core.Helpers
{
    public class ReportHelper
    {
        protected ExtentReports extent;
        protected ExtentTest test;

        public void InitReport()
        {
            extent = new ExtentReports();
            var spark = new ExtentSparkReporter(Path.Combine(Directory.GetCurrentDirectory(), "Reports", "Reports_" + DateTime.Now.ToFileTimeUtc() + ".html"));
            extent.AttachReporter(spark);
        }

        public void CreateTestCase(string testCaseTitle, string testCaseDescription)
        {
            test = extent.CreateTest(testCaseTitle, testCaseDescription);
        }

        public void LogMessageAndTakeScreenshot(string status, string detail, string imgBase64 = null)
        {
            switch (status)
            {
                case "Pass":
                    test.Log(Status.Pass, detail);
                    break;
                case "Fail":
                    test.Log(Status.Fail, detail);
                    break;
                case "Info":
                    test.Log(Status.Info, detail);
                    break;
            }

            if (!string.IsNullOrEmpty(imgBase64))
            {
                test.AddScreenCaptureFromBase64String(imgBase64);
            }
        }

        public void ExportReport()
        {
            extent.Flush();
        }
    }
}

