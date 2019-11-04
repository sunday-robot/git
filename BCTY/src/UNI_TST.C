union A {
	int a;
	struct {
		int a,b;
	} B;
};

union A a = -2, b = {-1, 2};
