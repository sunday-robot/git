import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Set;

public class PDV {
    public static void main(String[] args) {
	PlugIn a = new PlugIn("A");
	PlugIn b = new PlugIn("B");
	PlugIn c = new PlugIn("C");
	PlugIn d = new PlugIn("D");

	a.addRequiredPlugin(b);
	a.addRequiredPlugin(c);

	b.addRequiredPlugin(c);

	PlugInGroups pluginGroups = new PlugInGroups();
	pluginGroups.add(a);
	pluginGroups.add(b);
	pluginGroups.add(c);
	pluginGroups.add(d);

	System.out.printf("%s\n", pluginGroups.toString());

	for (PlugInGroup pg : pluginGroups) {
	    for (PlugIn p : pg) {
		System.out.printf("%s depth = %d\n", p.getName(), p.getDepth());
	    }
	}
    }

}

class PlugInGroups implements Iterable<PlugInGroup> {
    Set<PlugInGroup> allPlugInGroups = new HashSet<>();

    @Override
    public String toString() {
	StringBuffer s = new StringBuffer();
	s.append(super.toString() + "\n");
	for (PlugInGroup pg : allPlugInGroups) {
	    s.append(pg.toString());
	}
	return s.toString();
    }

    public void add(PlugIn plugin) {
	if (containts(plugin))
	    return;
	PlugInGroup pg = new PlugInGroup();
	pg.add(plugin);
	add(pg);
    }

    public void add(PlugInGroup pluginGroup) {
	allPlugInGroups.add(pluginGroup);
    }

    public boolean containts(PlugIn plugin) {
	for (PlugInGroup pluginGroup : allPlugInGroups) {
	    if (pluginGroup.containts(plugin))
		return true;
	}
	return false;
    }

    @Override
    public Iterator<PlugInGroup> iterator() {
	return allPlugInGroups.iterator();
    }
}

/** 依存関係のあるプラグインのグループ */
class PlugInGroup implements Iterable<PlugIn> {
    Set<PlugIn> allPlugIns = new HashSet<>();

    @Override
    public String toString() {
	StringBuffer s = new StringBuffer();
	s.append("  " + super.toString() + "\n");
	for (PlugIn p : allPlugIns) {
	    s.append(p.toString());
	}
	return s.toString();
    }

    public PlugInGroup() {

    }

    public boolean containts(PlugIn plugin) {
	return allPlugIns.contains(plugin);
    }

    public void add(PlugIn plugin) {
	if (containts(plugin))
	    return;
	allPlugIns.add(plugin);
	for (PlugIn requiedPlugin : plugin.getRequiredPlugIns()) {
	    add(requiedPlugin);
	}
    }

    @Override
    public Iterator<PlugIn> iterator() {
	return allPlugIns.iterator();
    }
}

class PlugIn {
    /** このプラグインの名前 */
    private final String name;

    /** このプラグインが必要としているプラグインのリスト */
    private final List<PlugIn> requiredPlugIns = new ArrayList<>();

    @Override
    public String toString() {
	StringBuffer s = new StringBuffer();
	s.append("      " + super.toString() + name + "\n");
	return s.toString();
    }

    public int getDepth() {
	if (requiredPlugIns.size() == 0) {
	    return 0;
	}
	int depth = 0;
	for (PlugIn reqIn : this.requiredPlugIns) {
	    depth = Math.max(depth, reqIn.getDepth());
	}
	return depth + 1;
    }

    public PlugIn(String name) {
	this.name = name;
    }

    public String getName() {
	return name;
    }

    public List<PlugIn> getRequiredPlugIns() {
	return requiredPlugIns;
    }

    public void addRequiredPlugin(PlugIn requiredPlugIn) {
	requiredPlugIns.add(requiredPlugIn);
    }

}