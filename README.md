MVD
===

## Push

       
        Url.Dispatcher().Push(new AddUserCommand {
                                    Id = Html.Selector.Name(r=>r.Id),
                                    Name = Html.Selector.Name(r=>r.Name),
                                                 })
                                                 
## Query as JSON

       
        Url.Dispatcher().Query(new GetCurrentDtQuery()).AsJson()
        
## Query as View

       
        Url.Dispatcher().Query(new GetCurrentDtQuery())
                        .AsView("~/Views/Home/Template.cshtml")
        
## View

       
        Url.Dispatcher().AsView("~/Views/Home/Template.cshtml")
        

                                                 
                                                 
* [More sample](http://blog.incframework.com/en/model-view-dispatcher/)
