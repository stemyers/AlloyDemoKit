﻿using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ContentQuery;
using EPiServer.Templates.Alloy.Models.Pages;
using EPiServer.Web;
using AlloyDemoKit.Models.Pages;
using PowerSlice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServer.Templates.Alloy.Business.PowerSlice
{
    using EPiServer.DataAbstraction;

    [ServiceConfiguration(typeof(IContentQuery)), ServiceConfiguration(typeof(IContentSlice))]
    public class ArticleSlice : ContentSliceBase<ArticlePage>
    {
        public override string Name
        {
            get { return "Articles"; }
        }
        public override IEnumerable<CreateOption> CreateOptions
        {
            get
            {
                var contentType = ContentTypeRepository.Load(typeof(ArticlePage));
                yield return new CreateOption(contentType.LocalizedName, EPiServer.DataFactory.Instance.Get<StartPage>(SiteDefinition.Current.StartPage).NewsPageLink, contentType.ID);
            }
        }
    }
}