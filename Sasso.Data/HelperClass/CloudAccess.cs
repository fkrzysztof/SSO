using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sasso.Data.HelperClass
{
    public class CloudAccess
    {
        private readonly Account account;
        private readonly Cloudinary cloudinary;
        private readonly CloudSecret cs = new CloudSecret();

        public CloudAccess()
        {

            account = new Account(cs.A, cs.B, cs.C);
            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }

        public string AddPic(IFormFile formFile, string folderName)
        {
            if(formFile == null)
            {
                return null;
            }
            ImageUploadParams uploadParams;
            string filename = formFile.FileName.Split('.')[0];
            uploadParams = new ImageUploadParams()
            {
                UseFilename = true,
                UniqueFilename = true,
                Overwrite = false,
                File = new FileDescription(filename, formFile.OpenReadStream()),
                Folder = folderName,
                Tags = folderName

            };
            var uploadResult = cloudinary.Upload(uploadParams);
            JToken token = JObject.Parse(uploadResult.JsonObj.ToString());
            return Convert.ToString(token.SelectToken("public_id"));
        }


        public string UploadRawType(IFormFile itemID, string folderName)
        {
            string filename = itemID.FileName.Split('.')[0];
            var RawUploadParams = new RawUploadParams()
            {
                Folder = folderName,
                UseFilename = true,
                Overwrite = true,
                Tags = folderName,
                File = new FileDescription(filename, itemID.OpenReadStream()),
            };
            var uploadResult = cloudinary.Upload(RawUploadParams);
            JToken token = JObject.Parse(uploadResult.JsonObj.ToString());
            return Convert.ToString(token.SelectToken("public_id"));
        }


        public string Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
                return "empty";
            var delResParams = new DelResParams()
            {
                PublicIds = new List<string> { id },
                KeepOriginal = false,
                Invalidate = true//,
                //ResourceType = ResourceType.Raw
            };
            JToken token = JObject.Parse(cloudinary.DeleteResources(delResParams).JsonObj.ToString());
            string rezult = Convert.ToString(token.SelectToken("deleted").SelectToken(id));
            return rezult;
        }

        public void Remove(List<string> listID)
        {
            var delResParams = new DelResParams()
            {
                PublicIds = listID,
                KeepOriginal = false,
                Invalidate = true
            };
            cloudinary.DeleteResources(delResParams);
        }


        public string GetImg(string img)
        {


            if (!string.IsNullOrEmpty(img))
            {
                var x = cloudinary.Api.UrlImgUp.BuildUrl(img);
                return x;
            }
            else
                return noPic();
        }


        public string GetImgJpg(string img)
        {
            if (!string.IsNullOrEmpty(img))
            {
                var x = cloudinary.Api.UrlImgUp.Transform(new Transformation()).Format("jpg").BuildUrl(img);
                return x;
            }
            else
                return noPic();
        }

        private string noPic()
        {
            return GetPicByTag("noPictureFile")[0].ToString();
        }

        public string GetLogo()
        {
            return GetPicByTag("Logo")[0].ToString();
        }

        public string GetLogoFooter()
        {
            return GetPicByTag("LogoFooter")[0].ToString();
        }
        
        public string GetLogoVertical()
        {
            return GetPicByTag("Logovertical")[0].ToString();
        }

        private List<string> GetPicByTag(string tag)
        {
            var rezult = cloudinary.ListResourcesByTag(tag).Resources;
            return getRezult(rezult);
        }

        private List<string> getRezult(Resource[] resource)
        {

            List<string> list = new List<String>();
            string temp;
            foreach (var item in resource)
            {
                temp = item.Url.ToString();
                if (!string.IsNullOrEmpty(temp))
                    list.Add(temp);
                else
                    list.Add(noPic());
            }
            return list;
        }

        public string ChangeItem(string oldItem, IFormFile newItem, string folderName)
        {

            if (newItem == null)
                return oldItem;

            if (!string.IsNullOrEmpty(oldItem))
            {
                Remove(oldItem);
                return AddPic(newItem, folderName);
            }
            else
                return AddPic(newItem, folderName);
        }
    }
}
