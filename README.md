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
<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th><th>Interception</th></tr>
<tr><th>No</th><td>95</td><td>95</td><td>96</td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>1065</td><td>1804</td><td>4706</td><td>33933</td></tr>
<tr><th>Caliburn.Micro 1.5.1</th><td>197</td><td>232</td><td>599</td><td></td></tr>
<tr><th>Catel 3.5</th><td>316</td><td>1061</td><td>2906</td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>88</td><td>110</td><td>172</td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><th>79</th><td>103</td><td>140</td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>3840</td><td>5132</td><td>3745</td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td>228</td><td>237</td><td>493</td><td></td></tr>
<tr><th>HaveBox 1.2.0</th><td>90</td><td>104</td><td>112</td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td>98</td><th>94</th><th>111</th><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>331</td><td>2550</td><td>13258</td><td></td></tr>
<tr><th>LightInject 3.0.0.5</th><td>174</td><td>175</td><td>306</td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>5286</td><td>18816</td><td>49871</td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>32538</td><td>37960</td><td>63920</td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>298</td><td>685</td><td>2225</td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>414</td><td>559</td><td>1585</td><td></td></tr>
<tr><th>Munq 3.1.6</th><td>89</td><td>108</td><td>395</td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>9225</td><td>19331</td><td>54477</td><td>22766</td></tr>
<tr><th>Petite 0.3.2</th><td>4969</td><td>5464</td><td>5235</td><td></td></tr>
<tr><th>SimpleInjector 2.2.3</th><td>112</td><td>103</td><td>154</td><th>507</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>1539</td><td>14989</td><td>36565</td><td>645</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1848</td><td>1924</td><td>6316</td><td>7777</td></tr>
<tr><th>StyleMVVM 3.0.0</th><td>303</td><td>332</td><td>465</td><td></td></tr>
<tr><th>TinyIOC 1.2</th><td>565</td><td>2315</td><td>8712</td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>3626</td><td>5269</td><td>14971</td><td>110805</td></tr>
<tr><th>Windsor 3.2.0</th><td>1203</td><td>3209</td><td>9508</td><td>16529</td></tr>
</table>
