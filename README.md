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
<tr><th>No</th><td>85</td><td>87</td><td>94</td><td>108</td></tr>
<tr><th>AutoFac 3.1.1</th><td>1030</td><td>1827</td><td>4728</td><td>13345</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>407</td><td>429</td><td>1188</td><td>4671</td></tr>
<tr><th>Catel 3.6</th><td>287</td><td>1643</td><td>4166</td><td>10969</td></tr>
<tr><th>Dynamo 3.0.2.0</th><td>112</td><td>122</td><td>181</td><td>498</td></tr>
<tr><th>fFastInjector 0.8.1</th><td>108</td><td>121</td><td>215</td><td>290</td></tr>
<tr><th>Funq 1.0.0.0</th><td>4208</td><td>3718</td><td>3957</td><td>4693</td></tr>
<tr><th>Griffin 1.1.0</th><td>214</td><td>247</td><td>578</td><td>1641</td></tr>
<tr><th>HaveBox 1.3.0</th><th>78</th><td>155</td><td>164</td><th>160</th></tr>
<tr><th>Hiro 1.0.3</th><td>158</td><td>152</td><td>198</td><td>283</td></tr>
<tr><th>IfFastInjector 0.1</th><td>100</td><th>114</th><th>136</th><td>187</td></tr>
<tr><th>LightCore 1.5.1</th><td>563</td><td>3404</td><td>23554</td><td>122358</td></tr>
<tr><th>LightInject 3.0.0.6</th><td>215</td><td>214</td><td>445</td><td>1041</td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>4210</td><td>18184</td><td>45612</td><td>123028</td></tr>
<tr><th>Mef 4.0.0.0</th><td>32294</td><td>36092</td><td>60634</td><td>121847</td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>244</td><td>743</td><td>2393</td><td>6411</td></tr>
<tr><th>Mugen 3.5.1</th><td>717</td><td>797</td><td>2139</td><td>7485</td></tr>
<tr><th>Munq 3.1.6</th><td>101</td><td>133</td><td>457</td><td>1517</td></tr>
<tr><th>Ninject 3.0.1.10</th><td>8669</td><td>17453</td><td>46348</td><td>128688</td></tr>
<tr><th>Petite 0.3.2</th><td>4383</td><td>4383</td><td>8463</td><td>5904</td></tr>
<tr><th>SimpleInjector 2.3.0</th><td>109</td><td>121</td><td>145</td><td>170</td></tr>
<tr><th>Spring.NET 1.3.2</th><td>1343</td><td>14101</td><td>34493</td><td>86438</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1658</td><td>1617</td><td>4810</td><td>13019</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>453</td><td>454</td><td>652</td><td>1065</td></tr>
<tr><th>TinyIoC 1.2</th><td>459</td><td>2119</td><td>7293</td><td>28159</td></tr>
<tr><th>Unity 3.0.1304.0</th><td>2858</td><td>4035</td><td>11335</td><td>34311</td></tr>
<tr><th>Windsor 3.2.1</th><td>817</td><td>2494</td><td>7000</td><td>18252</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Interception</th></tr>
<tr><th>No </th><td>121</td><td></td><td></td><td></td></tr>
<tr><th>AutoFac 3.1.1</th><td>21769</td><td>4030</td><td>11159</td><td></td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>6078</td><td></td><td>4927</td><td></td></tr>
<tr><th>Catel 3.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><th>657</th><td></td><td></td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td>3801</td><td></td><td></td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>HaveBox 1.3.0</th><td>929</td><td></td><td></td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td>2334</td><td></td><td></td><td></td></tr>
<tr><th>IfFastInjector 0.1</th><td></td><td></td><td></td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>2488</td><td>14964</td><td>35050</td><td></td></tr>
<tr><th>LightInject 3.0.0.6</th><td>1001</td><td></td><td></td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>128320</td><td>142964</td><td>97288</td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td>9259</td><td>6881</td><td>6041</td><td>3407</td></tr>
<tr><th>Munq 3.1.6</th><td>1284</td><td></td><td></td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>120968</td><td>50337</td><td>104014</td><td>72928</td></tr>
<tr><th>Petite 0.3.2</th><td>5418</td><td></td><td></td><td></td></tr>
<tr><th>SimpleInjector 2.3.0</th><td>1023</td><th>123</th><th>288</th><th>438</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>82708</td><td></td><td></td><td></td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>15357</td><td>3605</td><td>17070</td><td></td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>1339</td><td>1081</td><td>2527</td><td>2202</td></tr>
<tr><th>TinyIoC 1.2</th><td>3689</td><td>10123</td><td></td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td>34469</td><td></td><td>53755</td><td></td></tr>
<tr><th>Windsor 3.2.1</th><td>36533</td><td>6055</td><td>19566</td><td></td></tr>
</table>
