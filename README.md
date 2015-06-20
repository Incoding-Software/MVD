<h2 style="text-align: center;"><a href="http://blog.incframework.com/wp-content/uploads/2014/03/Article-5-small.png"><img class="aligncenter  wp-image-1421" alt="Article-5-small" src="http://blog.incframework.com/wp-content/uploads/2014/03/Article-5-small.png" /></a></h2>
<h2 style="text-align: center;"> Beginning</h2>
<strong>IML</strong> contributed greatly to a simpler way of creating ajax application due to the ability to divide complex <strong>Veiws</strong> into simple ones remarkably reducing the code and to increasing noteworthily <strong>Action</strong> in <strong>Controller</strong>.

<strong>MVD </strong> ( model view dispatcher )  is a design pattern to execute a <strong>Command</strong>/<strong>Query</strong> without writing an Action

For example:
<pre class="lang:c# decode:true">public ActionResult Details(GetUserDetailsQuery query)
{
    var model = dispatcher.Query(query);
    return IncView(model);
}</pre>
The code listing presents a common case when the <strong>Action</strong> returns <strong>View</strong>, Query ( GetUserDetailsQuery ) data driven. A <strong>Query</strong> hides properly most of the logic as it obtains all appropriate database and <strong>Event Broker</strong> instruments, as well as all the re-usable objects.

Refer to the example of the <strong>Action</strong> calling of <strong>View</strong>
<pre class="lang:c# decode:true">Html.When(JqueryBind.InitIncoding)
      .Do()
      .AjaxGet(Url.Action("Details","Users"))
      .OnSuccess(dsl = &gt; dsl.Self().Core().Insert.Html())
      .AsHtmlAttributes()
      .ToDiv()</pre>
Over time it requires to produce a <strong>Query</strong> and pass its <strong>View</strong> traversal of the <strong>Controller</strong>, as it is a simple intermediate link to be covered by tests and supported subsequently. The problem is not with creating many <strong>Action</strong>, but with their redundancy revealed after having studied the majority of scripts solved within <strong>CQRS</strong> architecture. The <strong>Controller</strong> produces a <strong>Dispatcher</strong> obtaining no advanced logic, with a few exceptions it is a typical mundane code.
<h2 style="text-align: center;">Write less, do more</h2>
Consider next a new <strong>View</strong> code
<pre class="lang:c# decode:true">Html.When(JqueryBind.InitIncoding)
      .Do()
      .AjaxGet(Url.Dispatcher()
                  .Query(new GetUserDetailsQuery())
                  .AsView("~/Admin/Views/Users/Details.cshtml"))
      .OnSuccess(dsl = &gt; dsl.Self().Core().Insert.Html())
      .AsHtmlAttributes()
      .ToDiv()</pre>
<strong>Url</strong> constructing is changed in the entry, now it is not a common Url.Action, but a specific builder to create a Query-based address and paths to View
<pre class="lang:c# decode:true">Url.Dispatcher()
   .Query(new GetUserDetailsQuery())
   .AsView("~/Admin/Views/Users/Details.cshtml")</pre>
The present code will work without writing an <strong>Action</strong> significantly saving time on development and maintenance.
<h2 style="text-align: center;">No More MVC ?</h2>
To answer the above question let us see how to integrate MVD into the project
<ul>
	<li> Create a <strong>DispatcherController</strong> (the name is of importance) inherited from the <strong>DispatcherControllerBase</strong> (set as default by version 1.1)</li>
</ul>
<pre class="lang:c# decode:true">public class DispatcherController : DispatcherControllerBase
{        
    public DispatcherController()
   : base(typeof(T).Assembly)
    {    }    
}</pre>
<em>Note: the <strong>Assembly</strong> comprising your <strong>Command/Query</strong> as well as other classes implemented in the <strong>View</strong> can be passed as a parameter to the constructor.</em>

<a href="https://bitbucket.org/incoding/incframework/src/2732c1f1d6e333a93a534ead1e61b3af024cad15/src/Incoding/MvcContrib/MVD/DispatcherControllerBase.cs?at=default">DispatcherControllerBase </a> includes the following <strong>Action:</strong>
<pre class="lang:c# decode:true">Query(string incType, string incGeneric, bool? incValidate)
Render(string incView, string incType, string incGeneric)
Push(string incType, string incGeneric)
Composite(string incTypes)
QueryToFile(string incType, string incGeneric, string incContentType, string incFileDownloadName)</pre>
One can construct url to perform a <strong>Push</strong> <strong>command</strong>
<pre class="lang:c# decode:true">Url.Action("Push", "Dispatcher", new  { incType = typeof(Command).Name } )</pre>
One can use the <strong>Url.Dispatcher</strong> to simplify building of url address
<pre class="lang:c# decode:true">Url.Dispatcher().Push(new Command())</pre>
<h2 style="text-align: center;">Application</h2>
<strong>MVD</strong> covers most of the frequent scenario in web-development powered by asp.net mvc.

<span style="color: #ff0000;"><em>Note: <span style="color: #0000ff;"><a href="https://github.com/IncodingSoftware/MVD"><span style="color: #0000ff;">Download</span></a>.</span> the examples</em></span>
<ul>
	<li><strong>Push</strong> for a single <strong>command</strong></li>
</ul>
<pre class="lang:c# decode:true">Html.When(JqueryBind.Click)
                  .Do()
                  .AjaxPost(Url.Dispatcher().Push(new AddUserCommand
                                                      {
                                                              Id = "59140B31-8BB2-49BA-AE52-368680D5418A",
                                                              Name = "Vlad"
                                                      }))
                  .OnSuccess(dsl = &gt; dsl.With(r = &gt; r.Id(containerId)).Core().Insert.Html())
                  .AsHtmlAttributes()
                  .ToButton("Run")</pre>
<em> Note: Selector can be used as values for parameters</em>
<ul>
	<li><strong>Push</strong> for a single <a href="http://msdn.microsoft.com/en-us/library/512aeb7t.aspx">generic </a><strong>command</strong></li>
</ul>
<pre class="lang:c# decode:true">Html.When(JqueryBind.Click)
                  .Do()
                  .AjaxPost(Url.Dispatcher().Push(new AddEntityCommand&lt;T&gt;()))
                  .OnSuccess(dsl = &gt; dsl.With(r = &gt; r.Id(containerId)).Core().Insert.Html())
                  .AsHtmlAttributes()
                  .ToButton("Run")</pre>
<em>Note: <strong>push</strong> returns the result and there is an array comprised the results of each <strong>command</strong> for the <strong>composite</strong></em>
<ul>
	<li>  <strong>Push</strong> for a <strong>command</strong> <strong>composite</strong></li>
</ul>
<pre class="lang:c# decode:true">Html.When(JqueryBind.Click)
                  .Do()
                  .AjaxPost(Url.Dispatcher()
                               .Push(new AddUserCommand { Id = "1", Name = "Name" })
                               .Push(new ApproveUserCommand { UserId = "2" }))
                  .OnSuccess(dsl = &gt; dsl.With(r = &gt; r.Id(containerId)).Core().Insert.Html())
                  .AsHtmlAttributes()
                  .ToButton("Run")</pre>
<em>  Note: be aware that in case parameter-names match, the value will be the same and from the last, and an extra prefix may be attached to the name in these situations. </em>
<ul>
	<li><strong>Query</strong> as <strong>Json</strong></li>
</ul>
<pre class="lang:c# decode:true">Html.When(JqueryBind.Click)
                  .Do()
                  .AjaxPost(Url.Dispatcher()
                               .Query(new GetCurrentDtQuery())
                               .AsJson())
                  .OnSuccess(dsl = &gt; dsl.With(r = &gt; r.Id(containerId)).Core().Insert.Html())
                  .AsHtmlAttributes()
                  .ToButton("Run")</pre>
<ul>
	<li><strong>Query</strong> ( <a href="http://msdn.microsoft.com/en-us/library/512aeb7t.aspx">generic</a>) as <strong>Json</strong></li>
</ul>
<pre class="lang:c# decode:true">Html.When(JqueryBind.Click)
                  .Do()
                  .AjaxPost(Url.Dispatcher()
                               .Query(new GetTypeNameQuery&lt;T&gt;())
                               .AsJson())
                  .OnSuccess(dsl = &gt; dsl.With(r = &gt; r.Id(containerId)).Core().Insert.Html())
                  .AsHtmlAttributes()
                  .ToButton("Run")</pre>
<ul>
	<li><strong> Query</strong> as <strong>View</strong></li>
</ul>
<pre class="lang:c# decode:true">Html.When(JqueryBind.Click)
                  .Do()
                  .AjaxPost(Url.Dispatcher()
                               .Query(new GetUserQuery())
                               .AsView("~/Views/Home/User.cshtml"))
                  .OnSuccess(dsl = &gt; dsl.With(r = &gt; r.Id(containerId)).Core().Insert.Html())
                  .AsHtmlAttributes()
                  .ToButton("Run")</pre>
<em>Note: <strong>View</strong> path is not built under the <strong>Controller</strong> in asp.net mvc, but the site root directory, to create any folder structure for <strong>View</strong> storage.  </em>
<ul>
	<li> <strong>Query</strong> as <strong>File</strong></li>
</ul>
<pre class="lang:c# decode:true">&lt;a href="@Url.Dispatcher().Query(new GetFileQuery()).AsFile(incFileDownloadName: "framework")"&gt;Download&lt;/a&gt;</pre>
<em>Note: building a File requires the <strong>Query</strong> to return <strong>byte</strong> ( byte[] ) array as a result </em>
<ul>
	<li><strong>Model</strong> as <strong>View</strong></li>
</ul>
<pre class="lang:c# decode:true">Html.When(JqueryBind.Click)
    .Do()
    .AjaxPost(Url.Dispatcher()
                 .Model(new GetUserQuery.Response
                             {
                               Id = "2",
                               Name = "Incoding Framework"
                              })
                 .AsView("~/Views/Home/User.cshtml"))
    .OnSuccess(dsl = &gt; dsl.With(r = &gt; r.Id(containerId)).Core().Insert.Html())
    .AsHtmlAttributes()
    .ToButton("Run")</pre>
Note: if the query is not completed via <strong>Ajax</strong>, it will result in <a href="http://msdn.microsoft.com/en-us/library/system.web.mvc.contentresult(v=vs.118).aspx">ContentResult  </a>rather than <strong>JSON</strong>
<ul>
	<li><strong>View</strong></li>
</ul>
<pre class="lang:c# decode:true">Html.When(JqueryBind.Click)
                  .Do()
                  .AjaxPost(Url.Dispatcher().AsView("~/Views/Home/Template.cshtml"))
                  .OnSuccess(dsl = &gt; dsl.With(r = &gt; r.Id(containerId)).Core().Insert.Html())
                  .AsHtmlAttributes()
                  .ToButton("Run")</pre>
<em> Note: the present way is well-suited to obtain the template via <strong>Ajax</strong></em>
<pre class="lang:c# decode:true">Selector urlTemplate = Url.Dispatcher().AsView("~/Views/Medication/Medication_Table_Row_Tmpl.cshtml").ToAjaxGet();
dsl.Self().Core().Insert.WithTemplate(urlTemplate).Append();</pre>
There is a very wide range of application for the <strong>MVD</strong>, the sequel will obtain an Async method support, thus, it can be certainly argued that there are enough capabilities to develop the project without any unified additional <strong>Controller</strong>.
<h2 style="text-align: center;">What has to be done if…?</h2>
Notice that lack of the <strong>Controller</strong> does not allow using <a href="http://msdn.microsoft.com/en-us/library/system.web.mvc.authorizeattribute(v=vs.118).aspx">attributes </a>implemented in different scripts. Let us consider the most frequent task virtually applied for any site, namely, a test for authorization.

Within asp.net mvc the task is solved using attributes to mark those Actions (or Controller) where validation logic is described, the present task can be solved in different ways in MVD:
<ul>
	<li>Mark with a DispatcherController attribute and in an attribute code. This method is very convenient if writing <a href="http://en.wikipedia.org/wiki/Customer_relationship_management">CRM </a>system and performing all the actions with authorization</li>
</ul>
<em>Note: the current requested address can be checked in the Allow List in the attribute code, i.e. executing the code if the address is not included into the List.</em>
<ul>
	<li>Use Dispatcher Event capabilities described in the <a href="http://blog.incframework.com/cqrs-advanced-course/">article</a></li>
</ul>
<em>Note: the Command/Query can be marked with attributes, which is similar to the standard asp.net mvc work</em>
<ul>
	<li>Implement the test for a client</li>
</ul>
<pre class="lang:c# decode:true">Html.When(JqueryBind.InitIncoding)
      .Do()
      .AjaxGet(Url.Dispatcher()
                  .Query(new IsAuthorizeDeviceQuery
                             {
                                     DeviceId = Selector.Incoding.Cookie(OnAddCookieEvent.DeviceIdKey)
                             })
                  .AsJson())
      .OnSuccess(dsl = &gt;
                     {
                         dsl.Self().Core().Break
                            .If(builder = &gt; builder.Data(r = &gt; r.Value == false));
                         //some code if authorize ok
                     })
      .OnBreak(dsl = &gt; dsl.Self().Core().Trigger.Invoke("SignIn"))
      .When("SignIn")
      .Do()
      .AjaxGet(Url.Dispatcher().AsView("~/Areas/Client/Views/Account/SingIn.cshtml"))
      .OnSuccess(dsl = &gt; dsl.With(r = &gt; r.Id(dialogId))
                           .Behaviors(inDsl = &gt;
                                          {
                                              inDsl.Core().Insert.Html();
                                              inDsl.JqueryUI().Dialog.Open(options = &gt;
                                                                               {
                                                                                   options.Title = "Sign in device";
                                                                               });
                                          }))
      .AsHtmlAttributes()
      .ToDiv()</pre>
The stepwise algorithm:
<ol>
	<li>After loading the element ( <strong>InitIncoding</strong> ) issue an Ajax query ( line 3)</li>
	<li>Check the result via <strong>OnSuccess</strong> , if the user is not authorized, choose Break</li>
	<li>If it is OnBreak, choose <strong>trigger</strong> for SignIn “leg” and give the dialogue with an authorization form</li>
	<li>If the code passes <strong>OnBreak</strong>, perform the actions to run page scripts</li>
</ol>
The code deals with most scripts and does not limit the spectrum (roles, rights, etc ) for tests, there is also а possibility to perform various tests depending on a page, i.e. constructing Home/Index and Dashboard/Index with different codes.
