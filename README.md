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
<tr><th>No</th><td>83</td><td>91</td><td>86</td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>1083</td><td>1862</td><td>4889</td><td>34170</td></tr>
<tr><th>Caliburn.Micro 1.5.1</th><td>236</td><td>270</td><td>691</td><td></td></tr>
<tr><th>Catel 3.5</th><td>336</td><td>1043</td><td>2869</td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>94</td><td>107</td><td>165</td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><th>84</th><td>103</td><td>141</td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>3317</td><td>3315</td><td>4592</td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td>212</td><td>226</td><td>476</td><td></td></tr>
<tr><th>HaveBox 1.2.0</th><td>97</td><td>112</td><th>113</th><td></td></tr>
<tr><th>Hiro 1.0.3</th><td>105</td><td>103</td><td>117</td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>314</td><td>2615</td><td>12366</td><td></td></tr>
<tr><th>LightInject 3.0.0.5</th><td>188</td><td>196</td><td>309</td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>4741</td><td>18709</td><td>48905</td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>36282</td><td>44585</td><td>71984</td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>356</td><td>851</td><td>2913</td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>593</td><td>757</td><td>1929</td><td></td></tr>
<tr><th>Munq 3.1.6</th><td>134</td><td>155</td><td>471</td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>9149</td><td>18013</td><td>52482</td><td></td></tr>
<tr><th>Petite 0.3.2</th><td>4676</td><td>4187</td><td>4330</td><td></td></tr>
<tr><th>SimpleInjector 2.2.3</th><td>90</td><th>99</th><td>114</td><th>424</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>1770</td><td>15221</td><td>36414</td><td>674</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1340</td><td>1474</td><td>4478</td><td>7754</td></tr>
<tr><th>TinyIOC 1.2</th><td>426</td><td>1744</td><td>6337</td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>2599</td><td>3856</td><td>11472</td><td>104434</td></tr>
<tr><th>Windsor 3.2.0</th><td>902</td><td>2453</td><td>7396</td><td>17114</td></tr>
</table>
