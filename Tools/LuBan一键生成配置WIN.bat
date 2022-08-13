set WORKSPACE=..

set GEN_CLIENT=dotnet %WORKSPACE%\Sub\luban_examples\Tools\Luban.ClientServer\Luban.ClientServer.dll

set CONF_ROOT=%WORKSPACE%\Sub\Luban

@ECHO =======================CLIENT==========================
%GEN_CLIENT% -j cfg --^
 -d %CONF_ROOT%\Defines\__root__.xml ^
 --input_data_dir %CONF_ROOT%\Datas ^
 --output_code_dir %WORKSPACE%\Unity\Assets\Scripts\Codes\Model\Share\Generate\Luban ^
 --output_data_dir %WORKSPACE%\Unity\Assets\Bundles\LubanBin ^
 --gen_types code_cs_bin,data_bin ^
 --external:selectors dotnet_cs,unity_cs ^
 -s client

pause