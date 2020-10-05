using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Orikivo.Systems.Services
{
    public class TemplateBuilder
    {
        const int iconPos = 0;
        const int largeLimit = 17;
        const int mediumLimit = 22;
        const int smallLimit = 31;
        const string baseProfileTemplate = ".//resources//profile//template.png";
        const string statusType = ".//resources//profile//status.png";
        const string iconSet = ".//resources//profile//icons.png";
        const string currencyAmountSet = ".//resources//profile//currency-symbols.png";

        public static Bitmap BuildNewLevelTemplate(Bitmap userAvatar)
        {
            const string baseLevelTemplate = ".//Templates//lvl_wide.png";
            var template = Image.FromFile(baseLevelTemplate);
            var avatar = userAvatar;
            var templateBuilder = new Bitmap(template.Width, template.Height, template.PixelFormat);
            using var graphic = Graphics.FromImage(templateBuilder);
            var templateSize = new Rectangle(0, 0, template.Width, template.Height);
            graphic.DrawImage(template, templateSize);
            template.Dispose();
            var avatarPosition = new Point(16, 16);
            graphic.DrawImage(userAvatar, avatarPosition);
            avatar.Dispose();
            return templateBuilder;
        }

        public static Bitmap BuildNewProfileBaseTemplate
        (Bitmap userAvatar,
            string userName,
            string userStatus,
            string userActivity,
            int userLevel,
            ulong userCurrency,
            ulong userExp, ulong nextLevelExp, PixelRenderingOptions options)
        {    
            #region Debug
            userName.Debug();
            userStatus.Debug();
            userActivity.Debug();
            userLevel.Debug();
            userCurrency.Debug();
            userExp.Debug();
            #endregion

            var template = Image.FromFile(baseProfileTemplate);            
            var avatar = userAvatar;
            var templateBuilder = new Bitmap(template.Width, template.Height, template.PixelFormat);
            using var graphics = Graphics.FromImage(templateBuilder);
            var templatePosition = new Rectangle(0, 0, template.Width, template.Height);
            graphics.DrawImage(template, templatePosition);
            template.Dispose();
            var avatarPosition = new Point(6, 6);
            graphics.DrawImage(avatar, avatarPosition);
            avatar.Dispose();

            //var extraSmallLimit = 37; //var setSize = "l";
            var sizeSpacing = userName.Length > largeLimit ? 6
                : userName.Length > mediumLimit ? 4
                : userName.Length > smallLimit ? 3
                : 8;

            var statusPosMapping = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "online", 0 }, { "idle", 2 }, { "afk", 2 }, { "donotdisturb", 4 },{ "offline", 6 },{ "invisible", 6 },
            };

            var statuses = new Bitmap(statusType);
            var statusPlacement = new Point(6, 39);
            if (statusPosMapping.ContainsKey(userStatus))
            {
                statusPosMapping.TryGetValue(userStatus, out int statusPos);
                var statusBarPosition = new Rectangle(0, statusPos, statuses.Width, 2);
                var statusBar = statuses.Clone(statusBarPosition, statuses.PixelFormat);
                var placeStatus = new Rectangle(statusPlacement, new Size(statusBar.Width, statusBar.Height));
                graphics.SetClip(placeStatus);
                graphics.DrawImage(statusBar, placeStatus);
            }

            //var levelLength = 0; //var levelString = string.Empty; //var baseActivityLength = 32;
            var icons = new Bitmap(iconSet);
            var iconLevelPosition = new Rectangle(iconPos, 0, 4, icons.Height);
            var iconCurrencyPosition = new Rectangle(8, 0, icons.Height, icons.Height);
            var currencyString = string.Empty;
            var actDetect = userActivity.Split();
            var baseSpacer = 6 + sizeSpacing + 2;

            var firstActivityLength = 32 - actDetect[0].Length;
            var secondActivityLength = 32;
            if (userActivity.StartsWith("listening to"))
            {
                var activityName = actDetect[0].Length + 1 + actDetect[1].Length;
                firstActivityLength = 32 - activityName;
            }

            var currencyPoint = new Point(40, baseSpacer + 6);
            var levelPoint = currencyPoint;
            var gameNameCharacters = userActivity.TrimEnd().ToCharArray();
            gameNameCharacters.Length.Debug();
            firstActivityLength.Debug();

            if (gameNameCharacters.Length - firstActivityLength > 0)
            {
                levelPoint.Y += 5;
                currencyPoint.Y += 5;
            }

            var currencyIcon = icons.Clone(iconCurrencyPosition, icons.PixelFormat);
            var levelIcon = icons.Clone(iconLevelPosition, icons.PixelFormat);
            var levelIndex = userLevel.ToString().ToCharArray();
            var levelWidth = 0;
            var levelIntCount = 0;
            var expLevelWidth = 0;
            foreach (var indexWidth in levelIndex)
            {
                if (indexWidth == '1')
                {
                    levelWidth += 3 + 1;
                    expLevelWidth += 3;
                }
                else
                {
                    levelWidth += 8 + 1;
                    expLevelWidth += 8;
                }
                levelIntCount += 1;
            }
            currencyPoint.X = 40 + levelWidth + 8;

            var levelString = $"{userLevel}"; //var currencyPos = 0;
            var currencyTypes = new Bitmap(currencyAmountSet);
            var currencyWidth = 10;
            var currencyTypePos = 0;
            var currencyTypePosition = new Rectangle(currencyTypePos, 0, currencyWidth, currencyTypes.Height);
            var currencyTypePoint = new Point(currencyPoint.X, baseSpacer + 8);

            if (gameNameCharacters.Length - firstActivityLength > 0)
            {
                currencyTypePoint.Y += 5;
            }

            var userCurrencyDigitCount = GetNumberLength(userCurrency);
            var currencyDetectDisplayWidth = userCurrencyDigitCount >= 12 ? userCurrencyDigitCount - 9
                : userCurrencyDigitCount >= 9 ? userCurrencyDigitCount - 6
                : userCurrencyDigitCount >= 6 ? userCurrencyDigitCount - 3
                : 0;

            #region unused
            if (userCurrencyDigitCount >= 9)
            {
                currencyWidth = 6;
                currencyTypePos = 20;
                currencyTypePosition = new Rectangle(currencyTypePos, 0, currencyWidth, currencyTypes.Height);
            }
            else if (userCurrencyDigitCount >= 6)
            {
                currencyWidth = 10;
                currencyTypePos = 10;
                currencyTypePosition = new Rectangle(currencyTypePos, 0, currencyWidth, currencyTypes.Height);
            }
            else if (userCurrencyDigitCount >= 3)
            {
                currencyWidth = 7;
                currencyTypePos = 0;
                currencyTypePosition = new Rectangle(currencyTypePos, 0, currencyWidth, currencyTypes.Height);              
            }
            #endregion

            if (userCurrencyDigitCount >= 3)
            {
                for (var currencyCount = 0; currencyCount < currencyDetectDisplayWidth; currencyCount++)
                {
                    currencyString += $"{GetNumberSpecificDigit(userCurrency, currencyCount, userCurrencyDigitCount)}";
                }
                if (!(GetNumberSpecificDigit(userCurrency, currencyString.Length, userCurrencyDigitCount) == 0))
                {
                    currencyString += $".0";
                }
            }
            else
            {
                currencyString += $"{userCurrency}";
            }

            currencyTypePoint.X += 8 + 1;
            foreach (var display in currencyString)
            {
                currencyTypePoint.X += display == '1' ? 3
                    : display == '.' ? 2
                    : 8;
                currencyTypePoint.X += 1;
            }

            var currencyTypeIcon = currencyTypes.Clone(currencyTypePosition, currencyTypes.PixelFormat);
            var levelPlacement = new Rectangle(levelPoint, new Size(4, 8));
            var currencyPlacement = new Rectangle(currencyPoint, new Size(8, 8));
            var currencyTypePlacement = new Rectangle(currencyTypePoint, new Size(currencyWidth, currencyTypes.Height));

            graphics.SetClip(levelPlacement);
            graphics.DrawImage(levelIcon, levelPlacement);
            levelPoint.X += 5;

            graphics.SetClip(currencyPlacement);
            graphics.DrawImage(currencyIcon, currencyPlacement);
            currencyPoint.X += 9;

            if (userCurrencyDigitCount >= 3 && userCurrencyDigitCount < 13)
            {
                graphics.SetClip(currencyTypePlacement);
                graphics.DrawImage(currencyTypeIcon, currencyTypePlacement);
            }

            if (userCurrencyDigitCount >= 13)
            {
                currencyString = "∞";
            }

            var expValue = userExp;
            var expMaxValue = nextLevelExp;
            var expBarWidth = expLevelWidth + levelIntCount - 1;
            var expPoint = new Point(40 + 5, baseSpacer + 6 + 8 + 1);
            if (gameNameCharacters.Length - firstActivityLength > 0)
            {
                expPoint.Y += 5;
            }
            var expPlacement = new Rectangle(expPoint, new Size(expBarWidth, 2));
            var fillBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
            var emptyBrush = new SolidBrush(Color.FromArgb(146, 146, 146));
            graphics.SetClip(expPlacement);
            graphics.FillRectangle(emptyBrush, expPlacement);

            ulong expSegment = expMaxValue / (ulong)expBarWidth;
            var fillExpPlacement = new Rectangle(expPoint, new Size(0, 2));

            if (expValue > expSegment)
            {
                for (ulong segment = 0; segment < (ulong)expBarWidth; segment++)
                {
                    if (expValue > segment * expSegment)
                    {
                        fillExpPlacement.Width += 1;
                    }
                }
                graphics.SetClip(fillExpPlacement);
                graphics.FillRectangle(fillBrush, fillExpPlacement);
            }

            graphics.ResetClip();

            var gameNameSet = userActivity.Split();
            var primaryGameName = string.Empty;
            var secondaryGameName = string.Empty;
            var primaryLength = 0;
            var secondaryLength = 0;

            var activityList = new[]
            {
                "playing ",
                "streaming ",
                "listening to ",
                "watching "
            };

            if (gameNameCharacters.Length >= firstActivityLength)
            {
                foreach (var name in gameNameSet)
                {
                    if (primaryLength >= firstActivityLength)
                    {
                        if (secondaryLength + name.Length <= secondActivityLength)
                        {
                            secondaryGameName += name + " ";
                            secondaryLength += name.Length;
                        }
                        else
                        {
                            secondaryGameName += "...";
                            break;
                        }
                    }
                    else
                    {
                        if (primaryLength + name.Length <= firstActivityLength)
                        {
                            if (string.Equals(name, "the", StringComparison.OrdinalIgnoreCase))
                            {
                                if (activityList.Contains(primaryGameName, StringComparer.OrdinalIgnoreCase))
                                {
                                    primaryGameName += name + " ";
                                    primaryLength += name.Length;
                                }
                                else
                                {
                                    secondaryGameName += name + " ";
                                    primaryLength += firstActivityLength - primaryLength;
                                    secondaryLength += name.Length;
                                }
                            }
                            else if (name.EndsWith(':'))
                            {
                                primaryGameName += name + " ";
                                primaryLength += firstActivityLength - primaryLength;
                            }
                            else
                            {
                                primaryGameName += name + " ";
                                primaryLength += name.Length;
                            }
                        }
                        else
                        {
                            if (secondaryLength + name.Length <= secondActivityLength)
                            {
                                secondaryGameName += name + " ";
                                secondaryLength += name.Length;
                            }
                            else
                            {
                                secondaryGameName += "...";
                                break;
                            }
                        }
                    }
                }


                if (!string.IsNullOrWhiteSpace(secondaryGameName))
                {
                    secondaryGameName = secondaryGameName.Remove(0, 1);
                }
                //TextConfiguration.PixelateText(primaryGameName, 40, baseSpacer, "s", templateBuilder);
                //TextConfiguration.PixelateText(secondaryGameName, 40, baseSpacer + 5, "s", templateBuilder)
            }
            //Bitmap lstr = PixelEngine.RenderString(levelString, options);
            //TextConfiguration.PixelateText(levelString, levelPoint.X, levelPoint.Y, "l", templateBuilder);
            //TextConfiguration.PixelateText(currencyString, currencyPoint.X, currencyPoint.Y, "l", templateBuilder);
            var un = PixelEngine.RenderString(userName, options);
            var gnPoint = new Point(40, 6 + un.Height + 2);
            graphics.DrawImage(un, new Point(40, 6));
            int levelCurrencyY = 6 + un.Height + 2;
            Bitmap gn;
            if (string.IsNullOrWhiteSpace(secondaryGameName))
            {
                gn = PixelEngine.RenderString(userActivity, options, 4);
                graphics.DrawImage(gn, gnPoint);
            }
            else
            {
                Bitmap pgn = PixelEngine.RenderString(primaryGameName, options, 4);
                graphics.DrawImage(pgn, gnPoint);
                levelCurrencyY += pgn.Height + 2;
                gn = PixelEngine.RenderString(secondaryGameName, options, 4);
                graphics.DrawImage(gn, new Point(40, 6 + un.Height + pgn.Height + 2 + 1));
            }
            levelCurrencyY += gn.Height + 2;

            graphics.DrawImage(PixelEngine.RenderString(levelString, options, 0),
                new Point(levelPoint.X, levelCurrencyY));
            graphics.DrawImage(PixelEngine.RenderString(currencyString, options, 0),
                new Point(currencyPoint.X, levelCurrencyY));
            //TextConfiguration.PixelateText(userName, 40, 6, setSize, templateBuilder);
            //TextConfiguration.PixelateText(userActivity, 40, 16, "s", templateBuilder);

            return templateBuilder.Color(options.Palette);
        }

        private static int GetNumberLength(ulong number)
        {
            return (int)Math.Ceiling(Math.Log10(number));
        }

        private static ulong GetNumberSpecificDigit(ulong number, int numberLength, int index)
        {
            return number / (ulong)Math.Pow(10, numberLength - index) % 10;
        }
    }
}

