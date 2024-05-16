using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(); //ekledik

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

app.UseSession();//ekledik

app.UseRouting();

app.UseAuthorization();	

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();
