param($rootPath, $toolsPath, $package, $project)

$source = Join-Path $toolsPath "/ServiceContainer.cs_"
$destination = Join-Path $toolsPath "/ServiceContainer.cs"


function PreProcess([string] $framework, [string] $nameSpace, [string]$sourceFile, [string]$destinationFile )
{
	$reader = New-Object System.IO.StreamReader ($sourceFile)
	$writer = New-Object System.IO.StreamWriter ($destinationFile)
	
	[bool]$shouldWrite = $true
	
	
	while (([string]$line = $reader.ReadLine()) -ne $null )
	{
		if($line.Contains("namespace LightInject"))
		{
			$line = $line.Replace('LightInject', $nameSpace)
		}
		
		if($line.Contains("public class MethodCallRewriter"))
		{
			$line = $line.Replace('public', 'internal')
		}
		
		if($line.StartsWith("#if") -or $line.StartsWith("#endif"))
		{		
			if($line.StartsWith("#if"))	
			{
				$stringExpression = $line.Substring(4).Trim();
				$shouldWrite = EvaluateExpression $stringExpression $framework
			}
			else
			{
				$shouldWrite = $true
			}		
		}
	
		if($line.StartsWith("#endif"))
		{		
			$shouldWrite = $true
		}
	
		if($shouldWrite -and -not $line.StartsWith("#") -and -not $line.StartsWith("//#"))
		{
			$writer.WriteLine($line)
		}		
	}
	
	$reader.Close();
	$reader.Dispose();
	
	$writer.Close();
	$writer.Dispose();		
}


function EvaluateExpression([string] $stringExpression, [string] $framework)
{
	[System.Linq.Expressions.Expression]$expression = CreateBinaryExpression $stringExpression $framework	
	$lambdaExpression = [System.Linq.Expressions.Expression]::Lambda($expression,$null) 
	$delegate =  $lambdaExpression.Compile() 
	$result = $delegate.Invoke()  
	return $result	
}


function CreateBooleanConstantExpression([string] $directive,[string]$framework )
{				
	if(($framework -eq $directive) -or  ($framework -eq $directive.SubString(1)))
	{
		if($directive.StartsWith("!"))
		{
			return [System.Linq.Expressions.Expression][System.Linq.Expressions.Expression]::Constant($false)
		}
		else
		{
			return [System.Linq.Expressions.Expression][System.Linq.Expressions.Expression]::Constant($true)
		}
	}
	else
	{
		if($directive.StartsWith("!"))
		{
			return [System.Linq.Expressions.Expression][System.Linq.Expressions.Expression]::Constant($true)
		}
		else
		{
			return [System.Linq.Expressions.Expression][System.Linq.Expressions.Expression]::Constant($false)
		}
	}
}

function CreateBinaryExpression([string] $stringExpression, [string]$framework)
{
	$parts = $stringExpression.Split(" ")
	
	[System.Linq.Expressions.Expression]$expression	| Out-Null	
	
	for($i=0;$i -le $parts.Length-1; $i++)
	{
		$part = $parts[$i].Trim()
		if($part -ne "&&" -and $part -ne "||")
		{			
			$expression = CreateBooleanConstantExpression $part $framework
		}
		else
		{
			$i++
			if($part -eq "&&")
			{				
				$part = $parts[$i].Trim()
				[System.Linq.Expressions.Expression]$rightExpression = CreateBooleanConstantExpression $part $framework
				$expression = [System.Linq.Expressions.Expression]::AndAlso($expression,$rightExpression)                
			}
			else
			{
				$part = $parts[$i].Trim()
				[System.Linq.Expressions.Expression]$rightExpression = CreateBooleanConstantExpression $part $framework
				$expression = [System.Linq.Expressions.Expression]::OrElse($expression,$rightExpression)
			}
		}		
	}			
	return [System.Linq.Expressions.Expression]$expression
}


$moniker = $project.Properties.Item("TargetFrameworkMoniker").Value
$frameworkName = new-object System.Runtime.Versioning.FrameworkName($moniker)

[string]$directive = "NET"

if ($frameworkName.Identifier -eq "Silverlight")
{
	$directive = "SILVERLIGHT"
}



"Resolved framework is: " + $directive | Out-Host

$nameSpace = $project.Properties.Item("DefaultNamespace").Value


PreProcess $directive $namespace $source $destination

$project.ProjectItems.Item("Dummy.txt").Delete()

$project.ProjectItems.AddFromFileCopy($destination)

Remove-Item $destination

#$project.DTE.ItemOperations.Navigate('https://github.com/seesharper/ExpressionTools/wiki/Documentation')
