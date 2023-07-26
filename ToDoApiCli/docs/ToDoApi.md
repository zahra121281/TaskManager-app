# ToDoApiCli.Api.ToDoApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ToDoCheckIdGet**](ToDoApi.md#todocheckidget) | **GET** /ToDo/check/{id} |  |
| [**ToDoGet**](ToDoApi.md#todoget) | **GET** /ToDo |  |
| [**ToDoItemidDelete**](ToDoApi.md#todoitemiddelete) | **DELETE** /ToDo/{itemid} |  |
| [**ToDoMakeDonePost**](ToDoApi.md#todomakedonepost) | **POST** /ToDo/make-done |  |
| [**ToDoPost**](ToDoApi.md#todopost) | **POST** /ToDo |  |
| [**ToDoTidGet**](ToDoApi.md#todotidget) | **GET** /ToDo/{tid} |  |
| [**ToDoTodayItemsGet**](ToDoApi.md#todotodayitemsget) | **GET** /ToDo/today-items |  |
| [**ToDoUpdatePost**](ToDoApi.md#todoupdatepost) | **POST** /ToDo/update |  |

<a name="todocheckidget"></a>
# **ToDoCheckIdGet**
> bool ToDoCheckIdGet (string id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ToDoApiCli.Api;
using ToDoApiCli.Client;
using ToDoApiCli.Model;

namespace Example
{
    public class ToDoCheckIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ToDoApi(config);
            var id = "id_example";  // string | 

            try
            {
                bool result = apiInstance.ToDoCheckIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ToDoApi.ToDoCheckIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ToDoCheckIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<bool> response = apiInstance.ToDoCheckIdGetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ToDoApi.ToDoCheckIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** |  |  |

### Return type

**bool**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todoget"></a>
# **ToDoGet**
> List&lt;Myitem&gt; ToDoGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ToDoApiCli.Api;
using ToDoApiCli.Client;
using ToDoApiCli.Model;

namespace Example
{
    public class ToDoGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ToDoApi(config);

            try
            {
                List<Myitem> result = apiInstance.ToDoGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ToDoApi.ToDoGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ToDoGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<Myitem>> response = apiInstance.ToDoGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ToDoApi.ToDoGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;Myitem&gt;**](Myitem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todoitemiddelete"></a>
# **ToDoItemidDelete**
> void ToDoItemidDelete (string itemid)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ToDoApiCli.Api;
using ToDoApiCli.Client;
using ToDoApiCli.Model;

namespace Example
{
    public class ToDoItemidDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ToDoApi(config);
            var itemid = "itemid_example";  // string | 

            try
            {
                apiInstance.ToDoItemidDelete(itemid);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ToDoApi.ToDoItemidDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ToDoItemidDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ToDoItemidDeleteWithHttpInfo(itemid);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ToDoApi.ToDoItemidDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **itemid** | **string** |  |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todomakedonepost"></a>
# **ToDoMakeDonePost**
> void ToDoMakeDonePost (Myitem myitem = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ToDoApiCli.Api;
using ToDoApiCli.Client;
using ToDoApiCli.Model;

namespace Example
{
    public class ToDoMakeDonePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ToDoApi(config);
            var myitem = new Myitem(); // Myitem |  (optional) 

            try
            {
                apiInstance.ToDoMakeDonePost(myitem);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ToDoApi.ToDoMakeDonePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ToDoMakeDonePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ToDoMakeDonePostWithHttpInfo(myitem);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ToDoApi.ToDoMakeDonePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **myitem** | [**Myitem**](Myitem.md) |  | [optional]  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todopost"></a>
# **ToDoPost**
> void ToDoPost (Myitem myitem = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ToDoApiCli.Api;
using ToDoApiCli.Client;
using ToDoApiCli.Model;

namespace Example
{
    public class ToDoPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ToDoApi(config);
            var myitem = new Myitem(); // Myitem |  (optional) 

            try
            {
                apiInstance.ToDoPost(myitem);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ToDoApi.ToDoPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ToDoPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ToDoPostWithHttpInfo(myitem);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ToDoApi.ToDoPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **myitem** | [**Myitem**](Myitem.md) |  | [optional]  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todotidget"></a>
# **ToDoTidGet**
> Myitem ToDoTidGet (string tid)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ToDoApiCli.Api;
using ToDoApiCli.Client;
using ToDoApiCli.Model;

namespace Example
{
    public class ToDoTidGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ToDoApi(config);
            var tid = "tid_example";  // string | 

            try
            {
                Myitem result = apiInstance.ToDoTidGet(tid);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ToDoApi.ToDoTidGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ToDoTidGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Myitem> response = apiInstance.ToDoTidGetWithHttpInfo(tid);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ToDoApi.ToDoTidGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **tid** | **string** |  |  |

### Return type

[**Myitem**](Myitem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todotodayitemsget"></a>
# **ToDoTodayItemsGet**
> List&lt;Myitem&gt; ToDoTodayItemsGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ToDoApiCli.Api;
using ToDoApiCli.Client;
using ToDoApiCli.Model;

namespace Example
{
    public class ToDoTodayItemsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ToDoApi(config);

            try
            {
                List<Myitem> result = apiInstance.ToDoTodayItemsGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ToDoApi.ToDoTodayItemsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ToDoTodayItemsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<Myitem>> response = apiInstance.ToDoTodayItemsGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ToDoApi.ToDoTodayItemsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;Myitem&gt;**](Myitem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todoupdatepost"></a>
# **ToDoUpdatePost**
> void ToDoUpdatePost (Myitem myitem = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ToDoApiCli.Api;
using ToDoApiCli.Client;
using ToDoApiCli.Model;

namespace Example
{
    public class ToDoUpdatePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ToDoApi(config);
            var myitem = new Myitem(); // Myitem |  (optional) 

            try
            {
                apiInstance.ToDoUpdatePost(myitem);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ToDoApi.ToDoUpdatePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ToDoUpdatePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ToDoUpdatePostWithHttpInfo(myitem);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ToDoApi.ToDoUpdatePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **myitem** | [**Myitem**](Myitem.md) |  | [optional]  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

