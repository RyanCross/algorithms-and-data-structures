namespace AlgorithmsAndDataStructures.src.util
{
    class GeneratePrimes
    {
        /**
         * Big(O) Time Complexity - n * 1/2n. So n^2.
         * 
         */
        public static int[] generate(int max)
        {
            // Find all primes less than max and insert them into an array
            int[] primes = new int[max];
            int primesIdx = 0;
            
            int i;
            for(i = 0; i < max - 1; i++)
            {
                if (i == 0)
                    continue;
                if (i % 2 == 0 && i > 2)
                    continue; //even numbers > 2 are never prime, cuts out half we have to iterate over twice
                if (i >= 2)
                {
                    for (int x = 2; x <= i; x++)
                    {
                        if (x == i) // if we make it to here without breaking
                        {
                            primes[primesIdx] = i;
                            primesIdx++;
                        }
                        if (i % x == 0)
                        {
                            break;
                        }
                    }
                }
            }
            return primes;
        }
    }
}
