using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace LateRooms.CI.Monitor.Web.Mvc
{
	public class ControllerFactory : DefaultControllerFactory
	{
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			try
			{
				if (controllerType == null)
					throw new HttpException((int)HttpStatusCode.NotFound, "Resource not found.");

				return ObjectFactory.GetInstance(controllerType) as Controller;
			}
			catch (StructureMapException)
			{
				System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
				throw;
			}
		}
	}
}
