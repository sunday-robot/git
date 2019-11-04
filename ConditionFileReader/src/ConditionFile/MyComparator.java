package ConditionFile;

import java.util.Comparator;
import java.util.List;

public final class MyComparator implements Comparator<List<String>> {
    @Override
    public int compare(List<String> arg0, List<String> arg1) {
	int size0 = arg0.size();
	int size1 = arg1.size();
	int size = Math.min(size0, size1);
	for (int i = 0; i < size; i++) {
	    String s0 = arg0.get(i);
	    String s1 = arg1.get(i);
	    int c = s0.compareTo(s1);
	    if (c == 0) {
		continue;
	    }
	    return c;
	}
	if (size0 == size1)
	    return 0;
	if (size0 > size1)
	    return 1;
	return -1;
    }

    @Override
    public boolean equals(java.lang.Object arg0) {
	return this == arg0;
    }
}
