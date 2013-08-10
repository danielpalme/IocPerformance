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
<tr><th>No</th><td>76</td><td>81</td><td>97</td><td>111</td></tr>
<tr><th>AutoFac 3.1.1</th><td>1137</td><td>1722</td><td>3976</td><td>10883</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>435</td><td>409</td><td>1132</td><td>4488</td></tr>
<tr><th>Catel 3.6</th><td>277</td><td>1756</td><td>4241</td><td>11326</td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>98</td><td>105</td><td>164</td><td>444</td></tr>
<tr><th>fFastInjector 0.8.1</th><td>86</td><td>113</td><td>140</td><td>216</td></tr>
<tr><th>Funq 1.0.0.0</th><td>127</td><td>131</td><td>289</td><td>952</td></tr>
<tr><th>Griffin 1.1.0</th><td>207</td><td>262</td><td>552</td><td>1475</td></tr>
<tr><th>HaveBox 1.4.0</th><th>72</th><td>107</td><th>106</th><td>144</td></tr>
<tr><th>Hiro 1.0.3</th><td>130</td><td>123</td><td>183</td><td>191</td></tr>
<tr><th>IfInjector 0.5</th><td>90</td><td>107</td><td>129</td><td>178</td></tr>
<tr><th>LightCore 1.5.1</th><td>451</td><td>2871</td><td>19797</td><td>102595</td></tr>
<tr><th>LightInject 3.0.0.6</th><td>190</td><td>184</td><td>325</td><td>828</td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>6384</td><td>28237</td><td>70343</td><td>189899</td></tr>
<tr><th>Mef 4.0.0.0</th><td>36949</td><td>40471</td><td>67467</td><td>131693</td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>335</td><td>956</td><td>3057</td><td>8282</td></tr>
<tr><th>Mugen 3.5.1</th><td>808</td><td>877</td><td>2169</td><td>7957</td></tr>
<tr><th>Munq 3.1.6</th><td>92</td><td>127</td><td>411</td><td>1355</td></tr>
<tr><th>Ninject 3.0.1.10</th><td>8997</td><td>18530</td><td>50983</td><td>138221</td></tr>
<tr><th>Petite 0.3.2</th><td>5715</td><td>5375</td><td>5651</td><td>7121</td></tr>
<tr><th>SimpleInjector 2.3.0</th><td>103</td><th>98</th><td>117</td><th>140</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>1641</td><td>16664</td><td>40305</td><td>101881</td></tr>
<tr><th>Stiletto 0.2.1.2</th><td>719</td><td>644</td><td>717</td><td>857</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>2178</td><td>2009</td><td>5984</td><td>15834</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>646</td><td>533</td><td>854</td><td>1317</td></tr>
<tr><th>TinyIoC 1.2</th><td>601</td><td>2723</td><td>9101</td><td>34886</td></tr>
<tr><th>Unity 3.0.1304.0</th><td>3492</td><td>4687</td><td>13843</td><td>41919</td></tr>
<tr><th>Windsor 3.2.1</th><td>931</td><td>2700</td><td>8108</td><td>20969</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Interception</th></tr>
<tr><th>No </th><td>125</td><td></td><td></td><td></td><td></td></tr>
<tr><th>AutoFac 3.1.1</th><td>20592</td><td>3495</td><td>10055</td><td></td><td>30659</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>5810</td><td></td><td>5222</td><td></td><td></td></tr>
<tr><th>Catel 3.6</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>584</td><td></td><td></td><td></td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>962</td><td></td><td></td><td></td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>HaveBox 1.4.0</th><td>829</td><td></td><td></td><td></td><th>583</th></tr>
<tr><th>Hiro 1.0.3</th><td>1880</td><td></td><td></td><td></td><td></td></tr>
<tr><th>IfInjector 0.5</th><td>287</td><td></td><td></td><td></td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>2111</td><td>12611</td><td>30342</td><td></td><td></td></tr>
<tr><th>LightInject 3.0.0.6</th><td>840</td><td></td><td></td><td></td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>139083</td><td>156400</td><td>103587</td><td></td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>9774</td><td>7483</td><td>6901</td><td>3562</td><td>21569</td></tr>
<tr><th>Munq 3.1.6</th><td>1160</td><td></td><td></td><td></td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>131647</td><td>57254</td><td>113691</td><td>79990</td><td>26303</td></tr>
<tr><th>Petite 0.3.2</th><td>9532</td><td></td><td></td><td></td><td></td></tr>
<tr><th>SimpleInjector 2.3.0</th><th>182</th><th>100</th><th>247</th><th>346</th><td>6177</td></tr>
<tr><th>Spring.NET 1.3.2</th><td>98173</td><td></td><td></td><td></td><td></td></tr>
<tr><th>Stiletto 0.2.1.2</th><td>906</td><td></td><td></td><td></td><td></td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>19103</td><td>4577</td><td>19800</td><td></td><td>11168</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>1604</td><td>1312</td><td>3493</td><td>2865</td><td></td></tr>
<tr><th>TinyIoC 1.2</th><td>4309</td><td>12615</td><td></td><td></td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>41871</td><td></td><td>65695</td><td></td><td>108377</td></tr>
<tr><th>Windsor 3.2.1</th><td>42784</td><td>7387</td><td>22505</td><td></td><td>18511</td></tr>
</table>
