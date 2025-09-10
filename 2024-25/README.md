# Creazione file

## Per sincronizzare repository locale e remoto

### Per inviare modifiche dal locale al remoto:
```bash
git add -A          # Solo se ci sono nuovi file
git commit -a -m "commit message"
git push
```
### Per inviare modifiche dal remoto al locale:
```bash
git pull
```

### Spiegazioni aggiuntive :

- `git add -A`: aggiunge tutti i nuovi file e le modifiche (inclusi i file cancellati).
- `git commit -a -m "messaggio"`: crea un commit con tutti i file tracciati modificati (non include nuovi file non aggiunti con `add`).
- `git push`: invia i commit locali al repository remoto.
- `git pull`: aggiorna il repository locale con i cambiamenti presenti su quello remoto.

