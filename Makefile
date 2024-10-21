build:
	dotnet build -c Release
	cp bin/Release/netstandard2.1/Trolldier.dll ~/U3DS/Servers/OpenModTest/OpenMod/plugins/Trolldier.dll
