public final class ArrayFork {
    public static void comparableSort(Comparable[] arr) {
        Comparable[] alt = new Comparable[arr.length];
        int d = arr.length % 2 == 0 ? -1 : 0;
        int h = arr.length / 2;
        int s;
        
        for (int i = 0; i < arr.length; i++) {
            s = d;
            
            for (int j = 0; j < arr.length; j++) {
                if (i != j) {
                    s += arr[i].compareTo(arr[j]);
                }
            }
            
            alt[s / 2 + h] = arr[i];
        }
        
        System.arraycopy(alt, 0, arr, 0, alt.length);
    }
}
