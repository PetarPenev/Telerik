using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;

namespace AddTextToImage
{
    public class ImageHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            using (var rectangleFont = new Font("Arial", 14, FontStyle.Bold))
            using (var bitmap = new Bitmap(context.Server.MapPath("image.png")))
            using (var g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                if (context.Request.HttpMethod == "GET")
                {
                    g.DrawString(context.Request.Params["imageText"], rectangleFont, SystemBrushes.WindowText, new PointF(10, 40));
                }
                else if (context.Request.HttpMethod == "POST")
                {
                    g.DrawString(context.Request.Form["imageText"], rectangleFont, SystemBrushes.WindowText, new PointF(10, 40));
                }

                context.Response.ContentType = "image/png";
                bitmap.Save(context.Response.OutputStream, ImageFormat.Png);
            }
        }

        #endregion
    }
}
