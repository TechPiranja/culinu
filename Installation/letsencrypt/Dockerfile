FROM ubuntu:latest

RUN apt-get update && apt-get -y install cron
RUN apt-get update && apt-get -y install certbot

RUN mkdir /etc/commands
COPY /commands/get-or-renew.sh /etc/commands/get-or-renew.sh
COPY /commands/get-or-renew-dry-run.sh /etc/commands/get-or-renew-dry-run.sh

#automatic renewal does not work yet; needs to auto create dns entries
#COPY /commands/renew-minutely-dry-run.sh /etc/cron.d/renew-minutely-dry-run.sh

# Give execution rights on the cron job
#RUN chmod 0744 /etc/cron.d/renew-minutely-dry-run.sh

# Apply cron job
#RUN crontab /etc/cron.d/renew-minutely-dry-run.sh

CMD ["cron", "-f"]