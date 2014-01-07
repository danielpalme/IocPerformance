Ioc Performance
===============

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](http://www.palmmedia.de)  
Twitter: [@danielpalme](http://twitter.com/danielpalme)  

Results
-------
<table>
<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th><th>Complex</th></tr>
<tr><th>No</th><td>86</td><td>102</td><td>100</td><td>112</td></tr>
<tr><th>Autofac 3.1.5 (http://code.google.com/p/autofac)</th><td>1196</td><td>844</td><td>1959</td><td>5746</td></tr>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>616</td><td>505</td><td>1402</td><td>5649</td></tr>
<tr><th>Catel 3.8.1 (http://www.catelproject.com)</th><td>374</td><td>4172</td><td>10039</td><td>26162</td></tr>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>113</td><th>124</th><td>187</td><td>511</td></tr>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td>154</td><td>140</td><td>187</td><td>314</td></tr>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>128</td><td>149</td><td>338</td><td>929</td></tr>
<tr><th>Grace 2.0.0-Nightly1084 (http://grace.codeplex.com)</th><td>408</td><td>364</td><td>679</td><td>1762</td></tr>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td>236</td><td>273</td><td>641</td><td>1788</td></tr>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>113</td><td>130</td><td>162</td><td>245</td></tr>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>178</td><td>164</td><td>191</td><td>244</td></tr>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>139</td><td>183</td><td>188</td><td>263</td></tr>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>590</td><td>4084</td><td>27527</td><td>142068</td></tr>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><td>134</td><th>124</th><th>134</th><th>176</th></tr>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td>4591</td><td>19513</td><td>48609</td><td>131236</td></tr>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>629</td><td>623</td><td>1360</td><td>4025</td></tr>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>36854</td><td>40314</td><td>65956</td><td>128156</td></tr>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td>281</td><td>809</td><td>2469</td><td>6928</td></tr>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>848</td><td>879</td><td>2203</td><td>8200</td></tr>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><th>104</th><td>162</td><td>707</td><td>2508</td></tr>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>9588</td><td>21141</td><td>52652</td><td>146061</td></tr>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>4711</td><td>4534</td><td>4745</td><td>5512</td></tr>
<tr><th>SimpleInjector 2.4.0 (http://simpleinjector.codeplex.com)</th><td>125</td><td>128</td><td>176</td><td>181</td></tr>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>1346</td><td>14122</td><td>34709</td><td>88035</td></tr>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>1795</td><td>1851</td><td>5298</td><td>13596</td></tr>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td>523</td><td>540</td><td>748</td><td>1583</td></tr>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>526</td><td>2325</td><td>7630</td><td>29731</td></tr>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>3082</td><td>4099</td><td>11828</td><td>35518</td></tr>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>754</td><td>2546</td><td>7382</td><td>19641</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Child Container</th><th>Interception</th></tr>
<tr><th>No</th><td>126</td><td>92</td><td>206</td><td>168</td>
<tr><th>Autofac 3.1.5 (http://code.google.com/p/autofac)</th><td>5785</td><td>4825</td><td>6063</td><td></td>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>7321</td><td></td><td>6318</td><td></td>
<tr><th>Catel 3.8.1 (http://www.catelproject.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>692</td><td></td><td></td><td></td>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>942</td><td></td><td></td><td></td>
<tr><th>Grace 2.0.0-Nightly1084 (http://grace.codeplex.com)</th><td>1875</td><td>959</td><td>2657</td><td>1631</td>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td><td></td><td></td>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>1088</td><td></td><td>592</td><td></td>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>2492</td><td></td><td></td><td></td>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>420</td><td>180</td><td></td><td></td>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>3105</td><td>17181</td><td>41974</td><td></td>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><th>189</th><th>125</th><th>194</th><th>217</th>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td><td></td><td></td>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>7540</td><td>1070</td><td>6553</td><td>2750</td>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>133749</td><td>152757</td><td>100467</td><td></td>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td><td></td><td></td>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>10065</td><td>7275</td><td>6733</td><td>3613</td>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td>1316</td><td></td><td></td><td></td>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>136267</td><td>57185</td><td>112568</td><td>80771</td>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>6387</td><td></td><td></td><td></td>
<tr><th>SimpleInjector 2.4.0 (http://simpleinjector.codeplex.com)</th><td>245</td><td>133</td><td>332</td><td>474</td>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>83205</td><td></td><td></td><td></td>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>15787</td><td>3998</td><td>19501</td><td></td>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td>1687</td><td>1221</td><td>3123</td><td>2566</td>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>4026</td><td>11058</td><td></td><td></td>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>37372</td><td></td><td>63100</td><td></td>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>38641</td><td>6609</td><td>21323</td><td></td>
</table>
Additional Advanced Features
<table>
<tr><th>Container</th><th>Child Container</th><th>Interception</th></tr>
<tr><th>No</th><td></td><td></td>
<tr><th>Autofac 3.1.5 (http://code.google.com/p/autofac)</th><td>60400</td><td>31459</td>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td></td><td></td>
<tr><th>Catel 3.8.1 (http://www.catelproject.com)</th><td></td><td></td>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td></td><td></td>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td></td><td></td>
<tr><th>Grace 2.0.0-Nightly1084 (http://grace.codeplex.com)</th><th>9300</th><td>6937</td>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td></td><th>623</th>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td></td><td></td>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td></td><td></td>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td></td><td></td>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><td></td><td>1139</td>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>2344900</td><td>7823</td>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td></td><td></td>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>498100</td><td>15908</td>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td></td><td></td>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>28558500</td><td>27259</td>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td></td><td></td>
<tr><th>SimpleInjector 2.4.0 (http://simpleinjector.codeplex.com)</th><td></td><td>10469</td>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td></td><td>60479</td>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>477600</td><td>9561</td>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td></td><td></td>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>12000</td><td></td>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>35100</td><td>106898</td>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>148400</td><td>17725</td>
</table>
