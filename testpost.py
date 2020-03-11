import requests

url = "http://10.10.7.68:8699/v1/scan/insertsn"

payload = "{\r\n\t\"MachineID\": \"1\",\r\n\t\"Time\": \"2019-11-28T15:33:26Z\",\r\n\t\"app\": \"LIGHTPOWER\",\r\n\t\"feature\": \"205276B8B426868FF5C34BBC3702B14B\",\r\n\t\"id\": 1,\r\n\t\"info\": \"{\\\"MachineID\\\":\\\"1\\\"}\\n\",\r\n\t\"macid\": \"AFDA8307551A859F474BA448E8058D3D\",\r\n\t\"modelname\": \"null\",\r\n\t\"ver\": 10000\r\n}"
headers = {
    'Content-Type': "application/json",
    'Authorization': "Basic YWRtaW46b3JiYmVj",
    'User-Agent': "PostmanRuntime/7.20.1",
    'Accept': "*/*",
    'Cache-Control': "no-cache",
    'Postman-Token': "520b3ee9-677b-4bf0-8108-a25273a1ed27,fcaacb1f-f242-4d86-b4c6-4ac8b44789c5",
    'Host': "10.10.7.68:8601",
    'Accept-Encoding': "gzip, deflate",
    'Content-Length': "263",
    'Connection': "keep-alive",
    'cache-control': "no-cache"
    }

response = requests.request("POST", url, data=payload, headers=headers)

print(response.text)

#print(response.text)
