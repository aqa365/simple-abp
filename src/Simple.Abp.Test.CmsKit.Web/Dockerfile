#基于 `mcr.microsoft.com/dotnet/core/aspnet` 来构建我们的镜像
FROM mcr.microsoft.com/dotnet/aspnet:6.0

#拷贝项目publish文件夹中的所有文件到 docker容器中的publish文件夹中  
COPY . /publish

#设置工作目录为 `/publish` 文件夹，即容器启动默认的文件夹
WORKDIR /publish

EXPOSE 8083

CMD ["dotnet", "Simple.Abp.Test.CmsKit.Web.dll", "--server.urls", "https://127.0.0.1:8083"]