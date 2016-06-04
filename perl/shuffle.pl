open(IN, '<', 'in.txt');
open(OUT, '>', 'out.txt');

@arr = ();

while (<IN>) {
  push(@arr, $_);
}

$len = scalar(@arr);

print "$len\n";

foreach $i (0..$len) {
  $j = int(rand($len));
  print "$i $j , ";
  ($arr[$i], $arr[$j]) = ($arr[$j], $arr[$i]);
}

for (@arr) {
  print OUT " - $_";
}
