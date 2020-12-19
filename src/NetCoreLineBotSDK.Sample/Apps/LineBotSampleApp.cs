using NetCoreLineBotSDK;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.Action;
using NetCoreLineBotSDK.Models.LineObject;
using NetCoreLineBotSDK.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Sample.Apps
{
    public class LineBotSampleApp : LineBotApp
    {
        private readonly ILineMessageUtility lineMessageUtility;
        public LineBotSampleApp(ILineMessageUtility _lineMessageUtility) : base(_lineMessageUtility)
        {
            lineMessageUtility = _lineMessageUtility;
        }

        protected override async Task OnMessageAsync(LineEvent ev)
        {
            if (ev.message.Text == "echo")
            {
                await lineMessageUtility.ReplyMessageAsync(ev.replyToken, $"You said:{ev.message.Text}");
            }

            if (ev.message.Text == "Demo Message")
            {
                // 多個輪播類型的 Message
                var carouselTemplate = new CarouselTemplate();
                var columns = new List<CarouselColumnMultipleAction>();
                columns.Add(new CarouselColumnMultipleAction()
                {
                    Title = "測試選單1",
                    Text = "副標題",
                    ThumbnailImageUrl = "https://imgur.com/HFssEJc.jpg",
                    Actions = new List<IAction>()
                {
                    new UriAction("https://dotnetconf2020.study4.tw/", ".NET Core Taiwan"),
                    new PostbackAction(@"par1@par2@par3","Postback"),
                    new MessageAction("Hello World","觸發使用者文字")
                }
                });
                carouselTemplate.Columns = columns;

                // 貼圖類型
                var sticker = new StickerMessage() { PackageId = "11539", StickerId = "52114136" };
                // 傳送多個Message
                await lineMessageUtility.ReplyMessageAsync(ev.replyToken, new List<IRequestMessage> {
                    carouselTemplate,
                    sticker
                });
            }

            if(ev.message.Text == "flex")
            {
                var flexJson = GetFlexJson();
                await lineMessageUtility.ReplyMessageByJsonAsync(ev.replyToken, flexJson);
            };
        }

        private string GetFlexJson()
        {
            return @"
{
  ""type"": ""carousel"",
  ""contents"": [
    {
      ""type"": ""bubble"",
      ""size"": ""nano"",
      ""header"": {
        ""type"": ""box"",
        ""layout"": ""vertical"",
        ""contents"": [
          {
            ""type"": ""text"",
            ""text"": ""In Progress"",
            ""color"": ""#ffffff"",
            ""align"": ""start"",
            ""size"": ""md"",
            ""gravity"": ""center""
          },
          {
            ""type"": ""text"",
            ""text"": ""70%"",
            ""color"": ""#ffffff"",
            ""align"": ""start"",
            ""size"": ""xs"",
            ""gravity"": ""center"",
            ""margin"": ""lg""
          },
          {
            ""type"": ""box"",
            ""layout"": ""vertical"",
            ""contents"": [
              {
                ""type"": ""box"",
                ""layout"": ""vertical"",
                ""contents"": [
                  {
                    ""type"": ""filler""
                  }
                ],
                ""width"": ""70%"",
                ""backgroundColor"": ""#0D8186"",
                ""height"": ""6px""
              }
            ],
            ""backgroundColor"": ""#9FD8E36E"",
            ""height"": ""6px"",
            ""margin"": ""sm""
          }
        ],
        ""backgroundColor"": ""#27ACB2"",
        ""paddingTop"": ""19px"",
        ""paddingAll"": ""12px"",
        ""paddingBottom"": ""16px""
      },
      ""body"": {
        ""type"": ""box"",
        ""layout"": ""vertical"",
        ""contents"": [
          {
            ""type"": ""box"",
            ""layout"": ""horizontal"",
            ""contents"": [
              {
                ""type"": ""text"",
                ""text"": ""Buy milk and lettuce before class"",
                ""color"": ""#8C8C8C"",
                ""size"": ""sm"",
                ""wrap"": true
              }
            ],
            ""flex"": 1
          }
        ],
        ""spacing"": ""md"",
        ""paddingAll"": ""12px""
      },
      ""styles"": {
        ""footer"": {
          ""separator"": false
        }
      }
    },
    {
      ""type"": ""bubble"",
      ""size"": ""nano"",
      ""header"": {
        ""type"": ""box"",
        ""layout"": ""vertical"",
        ""contents"": [
          {
            ""type"": ""text"",
            ""text"": ""Pending"",
            ""color"": ""#ffffff"",
            ""align"": ""start"",
            ""size"": ""md"",
            ""gravity"": ""center""
          },
          {
            ""type"": ""text"",
            ""text"": ""30%"",
            ""color"": ""#ffffff"",
            ""align"": ""start"",
            ""size"": ""xs"",
            ""gravity"": ""center"",
            ""margin"": ""lg""
          },
          {
            ""type"": ""box"",
            ""layout"": ""vertical"",
            ""contents"": [
              {
                ""type"": ""box"",
                ""layout"": ""vertical"",
                ""contents"": [
                  {
                    ""type"": ""filler""
                  }
                ],
                ""width"": ""30%"",
                ""backgroundColor"": ""#DE5658"",
                ""height"": ""6px""
              }
            ],
            ""backgroundColor"": ""#FAD2A76E"",
            ""height"": ""6px"",
            ""margin"": ""sm""
          }
        ],
        ""backgroundColor"": ""#FF6B6E"",
        ""paddingTop"": ""19px"",
        ""paddingAll"": ""12px"",
        ""paddingBottom"": ""16px""
      },
      ""body"": {
        ""type"": ""box"",
        ""layout"": ""vertical"",
        ""contents"": [
          {
            ""type"": ""box"",
            ""layout"": ""horizontal"",
            ""contents"": [
              {
                ""type"": ""text"",
                ""text"": ""Wash my car"",
                ""color"": ""#8C8C8C"",
                ""size"": ""sm"",
                ""wrap"": true
              }
            ],
            ""flex"": 1
          }
        ],
        ""spacing"": ""md"",
        ""paddingAll"": ""12px""
      },
      ""styles"": {
        ""footer"": {
          ""separator"": false
        }
      }
    },
    {
      ""type"": ""bubble"",
      ""size"": ""nano"",
      ""header"": {
        ""type"": ""box"",
        ""layout"": ""vertical"",
        ""contents"": [
          {
            ""type"": ""text"",
            ""text"": ""In Progress"",
            ""color"": ""#ffffff"",
            ""align"": ""start"",
            ""size"": ""md"",
            ""gravity"": ""center""
          },
          {
            ""type"": ""text"",
            ""text"": ""100%"",
            ""color"": ""#ffffff"",
            ""align"": ""start"",
            ""size"": ""xs"",
            ""gravity"": ""center"",
            ""margin"": ""lg""
          },
          {
            ""type"": ""box"",
            ""layout"": ""vertical"",
            ""contents"": [
              {
                ""type"": ""box"",
                ""layout"": ""vertical"",
                ""contents"": [
                  {
                    ""type"": ""filler""
                  }
                ],
                ""width"": ""100%"",
                ""backgroundColor"": ""#7D51E4"",
                ""height"": ""6px""
              }
            ],
            ""backgroundColor"": ""#9FD8E36E"",
            ""height"": ""6px"",
            ""margin"": ""sm""
          }
        ],
        ""backgroundColor"": ""#A17DF5"",
        ""paddingTop"": ""19px"",
        ""paddingAll"": ""12px"",
        ""paddingBottom"": ""16px""
      },
      ""body"": {
        ""type"": ""box"",
        ""layout"": ""vertical"",
        ""contents"": [
          {
            ""type"": ""box"",
            ""layout"": ""horizontal"",
            ""contents"": [
              {
                ""type"": ""text"",
                ""text"": ""Buy milk and lettuce before class"",
                ""color"": ""#8C8C8C"",
                ""size"": ""sm"",
                ""wrap"": true
              }
            ],
            ""flex"": 1
          }
        ],
        ""spacing"": ""md"",
        ""paddingAll"": ""12px""
      },
      ""styles"": {
        ""footer"": {
          ""separator"": false
        }
      }
    }
  ]
}
";

        }
    }
}
