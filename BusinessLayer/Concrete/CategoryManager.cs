﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Websitesinde yazılan bir blogda kurallarımız şunlar olsun;
-Blog adı boş geçilemez
-Blogun Content Alanı Boş geçilemez
-Yazılma tarihi boş geçilemez
-Blogun mutlaka bir kategorisi olmalı
-Blog adı en fazla 50 karakter olabilir.
-Blogda kullanılan resim maksimum 2 mb olabilir.
-Blogun en az 5 karakterden oluşan bir başlığı olmalıdır

->Bu kurallara validation rules denir.Bu kurallar businis katmanında concreteki classlar
absract'daki ınterfacelerden miras alarak oluşturulur.Bu işlemler yapılırken generic bir yapı 
oluşturulmalıdır.Bu işlemler if koşullarıyla business katmanında kontrol edilir daha sonra
istenilen kurallara uygun bir şekilde iş kodları yazılır.


 */


namespace BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;

        

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void CategoryAdd(Category category)
		{
			_categoryDal.Insert(category);

		}	
		

		public void CategoryDelete(Category category)
		{

			_categoryDal.Delete(category);	
		}

	

		public void CategoryUpdate(Category category)
		{
			_categoryDal.Update(category);
		}

		public Category GetByID(int id)
		{
			return _categoryDal.GetByID(id);
		}

		public List<Category> GetList()
		{
			return _categoryDal.GetListAll();
		}
	}
}
