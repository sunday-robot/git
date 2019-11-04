#include <tchar.h>
#include <boost/interprocess/managed_shared_memory.hpp>

const char *SHARED_MEMORY_NAME = "boost_shared_memory_test";

using namespace boost::interprocess;

static void shared_memory_test() {
	shared_memory_object::remove(SHARED_MEMORY_NAME);
	managed_shared_memory shm(open_or_create, SHARED_MEMORY_NAME, 1000000);

	shm.find_or_construct<unsigned char[1000]>("KByteArray");
}

int _tmain(int argc, _TCHAR* argv[]) {
	shared_memory_test();
	return 0;
}
