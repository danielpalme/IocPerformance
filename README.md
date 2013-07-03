Ioc Performance (Fork)
===============

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](http://www.palmmedia.de)  
Twitter: [@danielpalme](http://twitter.com/danielpalme)  

This is a fork to add more tests to daniel's origanl performance blog. The performance numbers generated below are very rough and on slower hardware than what daniel tests on. Don't take these as offical

Results
-------
<table>
<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th><th>Complex</th></tr>
<tr><th>No</th><td>78</td><td>78</td><td>81</td><td>96</td></tr>
<tr><th>AutoFac 3.0.2</th><td>1646</td><td>2766</td><td>6219</td><td>16903</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td>627</td><td>507</td><td>1397</td><td>5563</td></tr>
<tr><th>Catel 3.5</th><td>328</td><td>1200</td><td>3243</td><td>9081</td></tr>
<tr><th>Dynamo 3.0.2.0</th><th>79</th><td>119</td><td>179</td><td>444</td></tr>
<tr><th>fFastInjector 0.8.1</th><td>89</td><td>118</td><td>171</td><td>264</td></tr>
<tr><th>Funq 1.0.0.0</th><td>4053</td><td>3976</td><td>4214</td><td>5754</td></tr>
<tr><th>Griffin 1.1.0</th><td>241</td><td>267</td><td>613</td><td>1602</td></tr>
<tr><th>HaveBox 1.3.0</th><td>95</td><td>109</td><td>114</td><td>162</td></tr>
<tr><th>Hiro 1.0.3</th><td>117</td><th>108</th><th>109</th><td>185</td></tr>
<tr><th>LightCore 1.5.1</th><td>470</td><td>3685</td><td>24732</td><td>125519</td></tr>
<tr><th>LightInject 3.0.0.6</th><td>201</td><td>196</td><td>340</td><td>782</td></tr>
<tr><th>LinFu 2.3.0.41559</th><td>4950</td><td>20861</td><td>53351</td><td>145373</td></tr>
<tr><th>Mef 4.0.0.0</th><td>36696</td><td>42512</td><td>70174</td><td>139819</td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td>216</td><td>724</td><td>2467</td><td>6725</td></tr>
<tr><th>Mugen 3.5.1</th><td>550</td><td>712</td><td>1877</td><td>6875</td></tr>
<tr><th>Munq 3.1.6</th><td>99</td><td>146</td><td>531</td><td>1572</td></tr>
<tr><th>Ninject 3.0.1.10</th><td>10647</td><td>22383</td><td>60771</td><td>171190</td></tr>
<tr><th>Petite 0.3.2</th><td>4961</td><td>6327</td><td>5211</td><td>5820</td></tr>
<tr><th>SimpleInjector 2.2.3</th><td>97</td><td>117</td><td>133</td><th>156</th></tr>
<tr><th>Spring.NET 1.3.2</th><td>2030</td><td>16895</td><td>40363</td><td>103889</td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>1975</td><td>1779</td><td>5463</td><td>14388</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>631</td><td>528</td><td>726</td><td>1132</td></tr>
<tr><th>TinyIOC 1.2</th><td>510</td><td>2675</td><td>8204</td><td>31084</td></tr>
<tr><th>Unity 3.0.1304.0</th><td>3063</td><td>4730</td><td>13125</td><td>38858</td></tr>
<tr><th>Windsor 3.2.0</th><td>942</td><td>3952</td><td>9237</td><td>24377</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Generics</th><th>Multiple</th><th>Conditional</th><th>Interception</th></tr>
<tr><th>No</th><td></td><td></td><td></td><td></td></tr>
<tr><th>AutoFac 3.0.2</th><td>4740</td><td>14533</td><td></td><td>35762</td></tr>
<tr><th>Caliburn.Micro 1.5.2</th><td></td><td>5199</td><td></td><td></td></tr>
<tr><th>Catel 3.5</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Dynamo 3.0.2.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>fFastInjector 0.8.1</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Funq 1.0.0.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Griffin 1.1.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>HaveBox 1.3.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Hiro 1.0.3</th><td></td><td></td><td></td><td></td></tr>
<tr><th>LightCore 1.5.1</th><td>15908</td><td>38771</td><td></td><td></td></tr>
<tr><th>LightInject 3.0.0.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>LinFu 2.3.0.41559</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Mef 4.0.0.0</th><td>158170</td><td>107920</td><td></td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Mugen 3.5.1</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Munq 3.1.6</th><td></td><td></td><td></td><td></td></tr>
<tr><th>Ninject 3.0.1.10</th><td>64143</td><td>136413</td><td>96111</td><td>50732</td></tr>
<tr><th>Petite 0.3.2</th><td></td><td></td><td></td><td></td></tr>
<tr><th>SimpleInjector 2.2.3</th><th>120</th><td></td><td></td><th>21941</th></tr>
<tr><th>Spring.NET 1.3.2</th><td></td><td></td><td></td><td></td></tr>
<tr><th>StructureMap 2.6.4.1</th><td>4534</td><td>18169</td><td></td><td>23112</td></tr>
<tr><th>StyleMVVM 3.0.3</th><td>1266</td><th>3036</th><th>2479</th><td></td></tr>
<tr><th>TinyIOC 1.2</th><td>11395</td><td></td><td></td><td></td></tr>
<tr><th>Unity 3.0.1304.0</th><td></td><td></td><td></td><td>136390</td></tr>
<tr><th>Windsor 3.2.0</th><td>6138</td><td></td><td></td><td>38072</td></tr>
</table>
These results are autogenerated during debug runs, Don't read into the numbers till daniel posts them.
