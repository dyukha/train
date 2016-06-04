#for (my $i = 10; $i < 20; $i++) {
#    print " " x $i, "$i\n";
#}

#foreach (1..10) {
#    print " " x $_, "$_\n";
#};

#foreach ('aa'..'bb') {
#    print " " x 2, "$_\n";
#};

#foreach (my @a = ('hello world abc' =~ /(\w{2})/g)) {
#    print " " x 4, "$_\n";
#};

while (<*>) {
    print;
    print "\n";
    open (IN, $_) or die "Cannot open $_";
    while (<IN>) {
        s/foreach/ololo/g;
        print $_;
    }
    print "\n";
    print "-" x 40, "\n";
}
