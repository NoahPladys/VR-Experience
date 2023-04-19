## ML Agents deel III
Eerst heb ik een platform met een agent gemaakt. Vervolgens heb ik de agent de mogelijkheid gegeven om te springen, en heb ik deze rays gegeven. Daarna heb ik een object gemaakt dat targets spawnt. Deze targets krijgen bij instantiatie een force die richting de agent gaat, zodat ze naar de agent toe rollen. Wanneer deze de agent gepasseerd zijn despawnen de targets.

Elke episode spawnen er vijf targets. De tijd tussen de targets is tussen de 2 en 4 seconden, zodat de agent niet gewoon een patroon kan herkennen en op deze manier de targets gaat ontwijken. Wanneer het laatste target gedespawned is of de agent van het platform valt eindigt de episode en start de volgende.

De agent krijgt rewards bij de volgende gebeurtenissen
 - 1.25: Bij het begin van de episode

De agnet verliest rewards bij de volgende gebeurtenissen
 - 0.6: Wanneer de agent af het platform valt
 - 0.2: Bij elke target die de agent aanraakt
 - 0.05: Voor elke keer dat de agent springt

De agent start dus met een reward van 1.25, maar kan maximum eindigen met een reward van 1. Dit komt omdat hij minpunten krijgt voor elke sprong die hij maakt. Op deze manier zorgen we er voor dat de agent niet meer springt dan nodig is, aangezien er maar 5 targets komen per episode.

Wanneer de agent een target aanraakt verliest hij 0.2 reward, en wanneer hij van het platform valt verliest hij 0.6. Om een perfecte score van 1 te krijgen moet de agent dus slechts 5 keer springen om over elke target te geraken, zonder een target aan te raken, af het platform te vallen, of vaker te springen dan nodig.