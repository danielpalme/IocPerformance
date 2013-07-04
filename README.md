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
<tr><th>No</th><td>99</td><td>100</td><td>107</td><td>127</td></tr>
<tr><th>AutoFac 3.0.2</th><td>1151</td><td>1909</td><td>4426</td><td>12244</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>473</td><td>430</td><td>1191</td><td>4707</td></tr>
<tr><th>Catel 3.6</th><td>303</td><td>1770</td><td>4340</td><td>11849</td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>101</td><td>112</td><td>175</td><td>489</td></tr>
<tr><th>fFastInjector 0.8.1</th><td>87</td><td>113</td><td>153</td><td>222</td></tr>
<tr><th>Funq 1.0.0.0</th><td>3948</td><td>3928</td><td>4145</td><td>4753</td></tr>
<tr><th>Griffin 1.1.0</th><td>251</td><td>223</td><td>589</td><td>1494</td></tr>
<tr><th>HaveBox 1.3.0</th><th>86</th><th>105</th><th>104</th><th>151</th></tr>
<tr><th>Hiro 1.0.3</th><td>133</td><td>129</td><td>139</td><td>191</td></tr>
<tr><th>LightCore 1.5.1</th><td>469</td><td>3389</td><td>21821</td><td>109390</td></tr>
<tr><th>LightInject 3.0.0.6</th><td>206</td><td>212</td><td>350</td><td>828</td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>3801</td><td>18165</td><td>44668</td><td>120135</td></tr>
<tr><th>Mef 4.0.0.0</th><td>32060</td><td>37442</td><td>61856</td><td>122715</td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>236</td><td>701</td><td>2234</td><td>6411</td></tr>
<tr><th>Mugen 3.5.1</th><td>493</td><td>621</td><td>1631</td><td>6143</td></tr>
<tr><th>Munq 3.1.6</th><td>106</td><td>165</td><td>421</td><td>1345</td></tr>
<tr><th>Ninject 3.0.1.10</th><td>8830</td><td>18186</td><td>51600</td><td>143361</td></tr>
<tr><th>Petite 0.3.2</th><td>6215</td><td>5970</td><td>8681</td><td>11405</td></tr>
<tr><th>SimpleInjector 2.3.0</th><td>160</td><td>160</td><td>163</td><td>198</td></tr>
<tr><th>Spring.NET 1.3.2</th><td>2031</td><td>19097</td><td>46147</td><td>118864</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>2459</td><td>2219</td><td>6350</td><td>16977</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>638</td><td>591</td><td>822</td><td>1171</td></tr>
<tr><th>TinyIOC 1.2</th><td>710</td><td>3114</td><td>11571</td><td>43533</td></tr>
<tr><th>Unity 3.0.1304.0</th><td>3805</td><td>5163</td><td>14785</td><td>43782</td></tr>
<tr><th>Windsor 3.2.0</th><td>559</td><td>3894</td><td>8915</td><td>23406</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Generics</th><th>Multiple</th><th>Conditional</th><th>Interception</th></tr>
<tr><th>No</th><td></td><td></td><td></td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>3536</td><td>10469</td><td></td><th>31501</th></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td></td><td>4547</td><td></td><td></td></tr>
<tr><th>Catel 3.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>HaveBox 1.3.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td></td><td></td><td></td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>13802</td><td>33858</td><td></td><td></td></tr>
<tr><th>LightInject 3.0.0.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>143447</td><td>97531</td><td></td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Munq 3.1.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>56442</td><td>117387</td><td>80757</td><td>67224</td></tr>
<tr><th>Petite 0.3.2</th><td></td><td></td><td></td><td></td></tr>
<tr><th>SimpleInjector 2.3.0</th><th>159</th><th>430</th><td></td><td>39734</td></tr>
<tr><th>Spring.NET 1.3.2</th><td></td><td></td><td></td><td></td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>5078</td><td>22020</td><td></td><td>44710</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>1507</td><td>3345</td><th>2908</th><td></td></tr>
<tr><th>TinyIOC 1.2</th><td>15496</td><td></td><td></td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td></td><td>80964</td><td></td><td>163070</td></tr>
<tr><th>Windsor 3.2.0</th><td>7614</td><td>698</td><td></td><td>57151</td></tr>
</table>
