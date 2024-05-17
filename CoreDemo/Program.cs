using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



/*Authorization iþlemleri için yazdýk bu kod tüm sayfalara authorizaiton iþlemi olmadan girmemizi engeller
eðer sayfalarýn controllerindeki action fonksiyonunun baþýan [AllowAnonymous] yazarsak bu sayfalar bu kuraldan
muaf olur yani autharization gerçekleþmeden girebiliriz.
 */

builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.Build();
	config.Filters.Add(new AuthorizeFilter(policy));

}
);
/*Bu kod ile eðerki biz Authorization iþlemi yapmadan bir sayfa girmek isterse hata alýrýz bunun önüne geçebilmek
  bu kod bloðunu yazdýk yani buton authorization olmadan basýldýðýnda bizi o sayfa yerine login/ýndex sayfasýna 
  atacaktýr giriþ yapýldýktan sonra o sayfalara eriþim yapýlabileceðizdir.
*/
 //iki kodu ben yazdým footer da son 3 postu listele



builder.Services.AddMvc();
builder.Services.AddAuthentication(
	CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie( x =>
	{
		x.LoginPath = "/Login/Index";
	}

	);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");

	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

//Olmayan Bir sayfanýn urlsi girilirse seni atacaðý sayfa bu sayfadýr.
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();//otantike olmak için ekledik BU Autherization ile ilgili yazýlmasý lazým


app.UseRouting();

app.UseAuthorization();	

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();
