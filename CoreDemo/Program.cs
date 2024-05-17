using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



/*Authorization i�lemleri i�in yazd�k bu kod t�m sayfalara authorizaiton i�lemi olmadan girmemizi engeller
e�er sayfalar�n controllerindeki action fonksiyonunun ba��an [AllowAnonymous] yazarsak bu sayfalar bu kuraldan
muaf olur yani autharization ger�ekle�meden girebiliriz.
 */

builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.Build();
	config.Filters.Add(new AuthorizeFilter(policy));

}
);
/*Bu kod ile e�erki biz Authorization i�lemi yapmadan bir sayfa girmek isterse hata al�r�z bunun �n�ne ge�ebilmek
  bu kod blo�unu yazd�k yani buton authorization olmadan bas�ld���nda bizi o sayfa yerine login/�ndex sayfas�na 
  atacakt�r giri� yap�ld�ktan sonra o sayfalara eri�im yap�labilece�izdir.
*/
 //iki kodu ben yazd�m footer da son 3 postu listele



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

//Olmayan Bir sayfan�n urlsi girilirse seni ataca�� sayfa bu sayfad�r.
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();//otantike olmak i�in ekledik BU Autherization ile ilgili yaz�lmas� laz�m


app.UseRouting();

app.UseAuthorization();	

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();
