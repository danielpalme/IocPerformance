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
<tr><th>No</th><td>108</td><td>108</td><td>116</td><td>124</td></tr>
<tr><th>AutoFac 3.1.1</th><td>954</td><td>1420</td><td>3293</td><td>8708</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>453</td><td>380</td><td>958</td><td>3524</td></tr>
<tr><th>Catel 3.6</th><td>278</td><td>1291</td><td>3173</td><td>8159</td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>116</td><td>106</td><td>176</td><td>438</td></tr>
<tr><th>fFastInjector 0.8.1</th><th>84</th><th>104</th><td>128</td><td>179</td></tr>
<tr><th>Funq 1.0.0.0</th><td>2762</td><td>2767</td><td>2968</td><td>3432</td></tr>
<tr><th>Griffin 1.1.0</th><td>169</td><td>199</td><td>429</td><td>1166</td></tr>
<tr><th>HaveBox 1.4.0</th><td>117</td><td>144</td><td>146</td><td>175</td></tr>
<tr><th>Hiro 1.0.3</th><td>178</td><td>185</td><td>201</td><td>227</td></tr>
<tr><th>IfFastInjector 0.1</th><td>138</td><td>148</td><td>166</td><td>201</td></tr>
<tr><th>LightCore 1.5.1</th><td>494</td><td>2612</td><td>16789</td><td>86966</td></tr>
<tr><th>LightInject 3.0.0.6</th><td>249</td><td>201</td><td>323</td><td>736</td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>3231</td><td>13373</td><td>33308</td><td>90205</td></tr>
<tr><th>Mef 4.0.0.0</th><td>23957</td><td>27077</td><td>45612</td><td>90171</td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>203</td><td>512</td><td>1644</td><td>4452</td></tr>
<tr><th>Mugen 3.5.1</th><td>599</td><td>766</td><td>1614</td><td>5400</td></tr>
<tr><th>Munq 3.1.6</th><td>103</td><td>117</td><td>393</td><td>1188</td></tr>
<tr><th>Ninject 3.0.1.10</th><td>6190</td><td>14299</td><td>34828</td><td>95021</td></tr>
<tr><th>Petite 0.3.2</th><td>3500</td><td>3775</td><td>4390</td><td>4171</td></tr>
<tr><th>SimpleInjector 2.3.0</th><td>152</td><th>104</th><th>120</th><th>132</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>1130</td><td>10176</td><td>24361</td><td>60557</td></tr>
<tr><th>Stiletto 0.2.1.2</th><td>631</td><td>621</td><td>658</td><td>693</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1367</td><td>1304</td><td>3644</td><td>9455</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>428</td><td>444</td><td>562</td><td>810</td></tr>
<tr><th>TinyIoC 1.2</th><td>461</td><td>1843</td><td>5854</td><td>21620</td></tr>
<tr><th>Unity 3.0.1304.0</th><td>2219</td><td>2996</td><td>8126</td><td>24509</td></tr>
<tr><th>Windsor 3.2.1</th><td>661</td><td>1813</td><td>4888</td><td>12696</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Interception</th></tr>
<tr><th>No </th><td>141</td><td></td><td></td><td></td><td></td></tr>
<tr><th>AutoFac 3.1.1</th><td>16226</td><td>2829</td><td>7817</td><td></td><td>22625</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>4591</td><td></td><td>3808</td><td></td><td></td></tr>
<tr><th>Catel 3.6</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><th>548</th><td></td><td></td><td></td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>3681</td><td></td><td></td><td></td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>HaveBox 1.4.0</th><td>726</td><td></td><td></td><td></td><th>461</th></tr>
<tr><th>Hiro 1.0.3</th><td>1713</td><td></td><td></td><td></td><td></td></tr>
<tr><th>IfFastInjector 0.1</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>1822</td><td>10530</td><td>24630</td><td></td><td></td></tr>
<tr><th>LightInject 3.0.0.6</th><td>783</td><td></td><td></td><td></td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>94365</td><td>105885</td><td>69539</td><td></td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>6507</td><td>5054</td><td>4529</td><td>2582</td><td>22411</td></tr>
<tr><th>Munq 3.1.6</th><td>968</td><td></td><td></td><td></td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>88367</td><td>38983</td><td>79454</td><td>53735</td><td>18611</td></tr>
<tr><th>Petite 0.3.2</th><td>4532</td><td></td><td></td><td></td><td></td></tr>
<tr><th>SimpleInjector 2.3.0</th><td>754</td><th>131</th><th>232</th><th>430</th><td>6347</td></tr>
<tr><th>Spring.NET 1.3.2</th><td>57764</td><td></td><td></td><td></td><td></td></tr>
<tr><th>Stiletto 0.2.1.2</th><td>745</td><td></td><td></td><td></td><td></td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>11021</td><td>2729</td><td>12964</td><td></td><td>7002</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>1065</td><td>857</td><td>1973</td><td>1746</td><td></td></tr>
<tr><th>TinyIoC 1.2</th><td>2657</td><td>7934</td><td></td><td></td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>23906</td><td></td><td>38784</td><td></td><td>72216</td></tr>
<tr><th>Windsor 3.2.1</th><td>24870</td><td>4847</td><td>14205</td><td></td><td>12071</td></tr>
</table>
